using HRIS.Core.Interfaces.Services;
using HRIS.Core.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HRIS.App.Modules
{
    public static class CompanyModule
    {
        public static async void AddCompanyEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/Company");

            group.MapGet("/", [Authorize] async (ICompanyService companyService) => Results.Ok(await companyService.GetAll()));

            group.MapGet("/{id:Guid}", async (Guid id, ICompanyService companyService) => {

                var company = await companyService.GetById(id);

                if (company == null) return Results.NotFound();

                return Results.Ok(company);
            });
            group.MapGet("/search", [Authorize] async (string search, ICompanyService companyService) => {

                var company = await companyService.GetBySearch(search);
                return Results.Ok(company);
            });

            group.MapPost("/",  async (CompanyRequest request, ICompanyService companyService) =>
            {
                var newCompany = await companyService.Create(request);
                return Results.Created($"api/Company/{newCompany.Id}", newCompany);
            });
            group.MapPut("/{id:Guid}", [Authorize] async (Guid id, CompanyRequest request, ICompanyService companyService) => {

                var company = await companyService.Update(id, request);
                return Results.Ok(company);
            });
            group.MapDelete("/{id:Guid}", [Authorize] async (Guid id, ICompanyService companyService) =>
            {
                var success = await companyService.Delete(id);

                return !success ? Results.NotFound() : Results.NoContent();
            });


        }
    }
}
