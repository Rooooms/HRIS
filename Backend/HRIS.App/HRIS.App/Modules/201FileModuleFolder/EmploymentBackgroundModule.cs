using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class EmploymentBackgroundModule
    {
        public static async void AddEmploymentBackgroundEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/EmploymentBackground");

            group.MapGet("/", async (IEmploymentBackgroundService employeeBackgroundService) => Results.Ok(await employeeBackgroundService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IEmploymentBackgroundService employeeBackgroundService) => {

                var employmentBackground = await employeeBackgroundService.GetById(id);

                if (employmentBackground == null) return Results.NotFound();

                return Results.Ok(employmentBackground);
            });


            group.MapPost("/", async (Guid id, EmploymentBackgroundRequest request, IEmploymentBackgroundService employeeBackgroundService) =>
            {
                var newEmploymentBackground = await employeeBackgroundService.Create(id, request);
                return Results.Created($"api/EmploymentBackground/{newEmploymentBackground.Id}", newEmploymentBackground);
            });
            group.MapPut("/{id:Guid}", async (Guid id, EmploymentBackgroundRequest request, IEmploymentBackgroundService employeeBackgroundService) => {

                var employmentBackground = await employeeBackgroundService.Update(id, request);
                return Results.Ok(employmentBackground);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IEmploymentBackgroundService employeeBackgroundService) =>
            {
                var success = await employeeBackgroundService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
