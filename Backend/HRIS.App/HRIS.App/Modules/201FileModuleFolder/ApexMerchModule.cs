using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class ApexMerchModule
    {
        public static async void AddApexMerchEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/ApexMerch");

            group.MapGet("/", async (IApexMerchService apexMerchService) => Results.Ok(await apexMerchService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IApexMerchService apexMerchService) => {

                var apexMerch = await apexMerchService.GetById(id);

                if (apexMerch == null) return Results.NotFound();

                return Results.Ok(apexMerch);
            });


            group.MapPost("/", async (Guid id, ApexMerchRequest request, IApexMerchService apexMerchService) =>
            {
                var newApexMerch = await apexMerchService.Create(id, request);
                return Results.Created($"api/Benefit/{newApexMerch.Id}", newApexMerch);
            });
            group.MapPut("/{id:Guid}", async (Guid id, ApexMerchRequest request, IApexMerchService apexMerchService) => {

                var apexMerch = await apexMerchService.Update(id, request);
                return Results.Ok(apexMerch);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IApexMerchService apexMerchService) =>
            {
                var success = await apexMerchService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
