using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class EmployeeDetailsModule
    {
        public static async void AddEmployeeDetailsEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/EmployeeDetails");

            group.MapGet("/", async (IEmployeeDetailService employeeDetailService) => Results.Ok(await employeeDetailService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IEmployeeDetailService employeeDetailService) => {

                var employeeDetails = await employeeDetailService.GetById(id);

                if (employeeDetails == null) return Results.NotFound();

                return Results.Ok(employeeDetails);
            });
            group.MapGet("/search", async (string search, IEmployeeDetailService employeeDetailService) => {

                var employeeDetails = await employeeDetailService.GetBySearch(search);
                return Results.Ok(employeeDetails);
            });

            group.MapPost("/", async (EmployeeDetailsRequest request, IEmployeeDetailService employeeDetailService) =>
            {
                var newemployeeDetails = await employeeDetailService.Create(request);
                return Results.Created($"api/Employee/{newemployeeDetails.Id}", newemployeeDetails);
            });
            group.MapPut("/{id:Guid}", async (Guid id, EmployeeDetailsRequest request, IEmployeeDetailService employeeDetailService) => {

                var employeeDetails = await employeeDetailService.Update(id, request);
                return Results.Ok(employeeDetails);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IEmployeeDetailService employeeDetailService) =>
            {
                var success = await employeeDetailService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
