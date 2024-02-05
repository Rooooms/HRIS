using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class RequirementModule
    {
        public static async void AddRequirementEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Requirement");

            group.MapGet("/", async (IRequirementService requirmentService) => Results.Ok(await requirmentService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IRequirementService requirmentService) => {

                var requirement = await requirmentService.GetById(id);

                if (requirement == null) return Results.NotFound();

                return Results.Ok(requirement);
            });


            group.MapPost("/", async (Guid id, RequirementsRequest request, IRequirementService requirmentService) =>
            {
                var newRequirments = await requirmentService.Create(id, request);
                return Results.Created($"api/Requirement/{newRequirments.Id}", newRequirments);
            });
            group.MapPut("/{id:Guid}", async (Guid id, RequirementsRequest request, IRequirementService requirmentService) => {

                var requirement = await requirmentService.Update(id, request);
                return Results.Ok(requirement);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IRequirementService requirmentService) =>
            {
                var success = await requirmentService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
