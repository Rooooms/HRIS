using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class BenefitModule
    {
        public static async void AddBenefitEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Benefit");

            group.MapGet("/", async (IBenefitService benefitService) => Results.Ok(await benefitService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IBenefitService benefitService) => {

                var benefit = await benefitService.GetById(id);

                if (benefit == null) return Results.NotFound();

                return Results.Ok(benefit);
            });


            group.MapPost("/", async (Guid id, BenefitRequest request, IBenefitService benefitService) =>
            {
                var newBenefit = await benefitService.Create(id, request);
                return Results.Created($"api/Benefit/{newBenefit.Id}", newBenefit);
            });
            group.MapPut("/{id:Guid}", async (Guid id, BenefitRequest request, IBenefitService benefitService) => {

                var benefit = await benefitService.Update(id, request);
                return Results.Ok(benefit);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IBenefitService benefitService) =>
            {
                var success = await benefitService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
