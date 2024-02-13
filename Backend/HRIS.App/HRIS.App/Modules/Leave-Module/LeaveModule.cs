
using HRIS.Core.Interfaces.Services.Leave_Service;
using HRIS.Core.Interfaces.Services.User_Service;
using HRIS.Core.Models.Requests;
using HRIS.Core.Models.Requests.Leave_Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HRIS.App.Modules.Leave_Module
{
    public static class LeaveModule
    {
        public static async void AddLeaveEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Leave").RequireAuthorization();

            group.MapGet("/", [Authorize] async (ILeaveService leaveService) => Results.Ok(await leaveService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, ILeaveService leaveService) => {

                var leave = await leaveService.GetById(id);

                if (leave == null) return Results.NotFound();

                return Results.Ok(leave);
            });



            group.MapGet("/my-leaves", async (HttpContext context, ILeaveService leaveService) =>
            {
                var employeeNumberClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

                if (employeeNumberClaim == null || !int.TryParse(employeeNumberClaim.Value, out var employeeNumber))
                {
                    // Handle the case where the user is not authenticated or employeeNumber is not valid.
                    return Results.Unauthorized();
                }

                var leaves = await leaveService.GetLeavesByEmployeeNumber(employeeNumber);

                if (leaves != null && leaves.Any())
                {
                    return Results.Ok(leaves);
                }
                else
                {
                    return Results.NotFound("No leave records found for the logged-in user.");
                }
            });

            group.MapGet("/department", async ( ILeaveService leaveService, string department) => {

                var leave = await leaveService.GetLeavesByDepartment(department);

                if (leave == null) return Results.NotFound();

                return Results.Ok(leave);
            });




            group.MapPost("/", async (HttpContext context, LeaveRequest request, ILeaveService leaveService) =>
            {
                var newLeave = await leaveService.Create(context, request);

                //if (newLeave != null)
                
                    Console.WriteLine("New Leave", newLeave);
                    return Results.Created($"api/Leave/{newLeave.Id}", newLeave);

                //else
                //{
                //    // Handle the case where leave creation failed
                //    return Results.BadRequest("Failed to create leave");
                //}
            });
            group.MapPut("/{id:Guid}", async (Guid id, LeaveRequest request, ILeaveService leaveService) =>
            {

                var leave = await leaveService.Update(id, request);
                return Results.Ok(leave);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, ILeaveService leaveService) =>
            {
                var success = await leaveService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
