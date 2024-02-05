using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class SalaryModule
    {
        public static async void AddSalaryEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Salary").RequireAuthorization();

            group.MapGet("/", async (ISalaryService salaryService) => Results.Ok(await salaryService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, ISalaryService salaryService) => {

                var salary = await salaryService.GetById(id);

                if (salary == null) return Results.NotFound();

                return Results.Ok(salary);
            });


            group.MapPost("/", async (Guid id, SalaryRequest request, ISalaryService salaryService) =>
            {
                var newSalary = await salaryService.Create(id, request);
                return Results.Created($"api/Salary/{newSalary.Id}", newSalary);
            });
            group.MapPut("/{id:Guid}", async (Guid id, SalaryRequest request, ISalaryService salaryService) => {

                var salary = await salaryService.Update(id, request);
                return Results.Ok(salary);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, ISalaryService salaryService) =>
            {
                var success = await salaryService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
