using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;

namespace HRIS.App.Modules
{
    public static class PaymastModule
    {
        public static async void AddPaymastEndPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Paymast");

            group.MapGet("/", async (IPaymastService paymastService) => Results.Ok(await paymastService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, IPaymastService paymastService) => {

                var paymast = await paymastService.GetById(id);

                if (paymast == null) return Results.NotFound();

                return Results.Ok(paymast);
            });


            group.MapPost("/", async (Guid id, PaymastRequest request, IPaymastService paymastService) =>
            {
                var newPaymast = await paymastService.Create(id, request);
                return Results.Created($"api/Paymast/{newPaymast.Id}", newPaymast);
            });
            group.MapPut("/{id:Guid}", async (Guid id, PaymastRequest request, IPaymastService paymastService) => {

                var paymast = await paymastService.Update(id, request);
                return Results.Ok(paymast);
            });
            group.MapDelete("/{id:Guid}", async (Guid id, IPaymastService paymastService) =>
            {
                var success = await paymastService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
