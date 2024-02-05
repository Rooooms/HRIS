using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class BranchModule
    {
        public static async void AddBranchEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Branch");

            group.MapGet("/", async (IBranchService branchService) => Results.Ok(await branchService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IBranchService branchService) => {

                var branch = await branchService.GetById(id);

                if (branch == null) return Results.NotFound();

                return Results.Ok(branch);
            });
            group.MapGet("/search", async (string search, IBranchService branchService) => {

                var branch = await branchService.GetBySearch(search);
                return Results.Ok(branch);
            });
            group.MapGet("/{id}/{CompanyId}", async (Guid CompanyId, IBranchService branchService) =>
            {
                var branch = await branchService.GetBranchByCompanyId(CompanyId);
                if (branch == null)
                    return Results.NotFound("NOT FOUND");
                return Results.Ok(branch);
            });

            group.MapPost("/", async (BranchRequest request, IBranchService branchService) =>
            {
                var newBranch = await branchService.Create(request);
                return Results.Created($"api/Branch/{newBranch.Id}", newBranch);
            });
            group.MapPut("/{id:Guid}", async (Guid id, BranchRequest request, IBranchService branchService) => {

                var branch = await branchService.Update(id, request);
                return Results.Ok(branch);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IBranchService branchService) =>
            {
                var success = await branchService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
