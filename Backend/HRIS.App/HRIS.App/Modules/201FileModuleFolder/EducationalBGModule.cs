using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class EducationalBGModule
    {
        public static async void AddEducationalBGEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/EducationalBg");

            group.MapGet("/", async (IEducationalBGService educationalBGService) => Results.Ok(await educationalBGService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IEducationalBGService educationalBGService) => {

                var educationalBG = await educationalBGService.GetById(id);

                if (educationalBG == null) return Results.NotFound();

                return Results.Ok(educationalBG);
            });
            group.MapGet("/{id}/{EmployeeId}", async (Guid employeeId, IEducationalBGService educationalBGService) =>
            {
                var educationalBG = await educationalBGService.GetEducationalBgbyEmployeeId(employeeId);
                if (educationalBG == null)
                    return Results.NotFound("NOT FOUND");
                return Results.Ok(educationalBG);
            });


            group.MapPost("/", async (Guid id, EducationalBGRequest request, IEducationalBGService educationalBGService) =>
            {
                var newEducationBG = await educationalBGService.Create(id, request);
                return Results.Created($"api/EducationalBg/{newEducationBG.Id}", newEducationBG);
            });
            group.MapPut("/{id:Guid}", async (Guid id, EducationalBGRequest request, IEducationalBGService educationalBGService) => {

                var educationalBG = await educationalBGService.Update(id, request);
                return Results.Ok(educationalBG);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IEducationalBGService educationalBGService) =>
            {
                var success = await educationalBGService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
