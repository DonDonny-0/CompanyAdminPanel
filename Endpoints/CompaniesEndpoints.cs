namespace CompanyAdminPanel.Endpoints;

using CompanyAdminPanel.Data;
using CompanyAdminPanel.Dtos;
// using CompanyAdminPanel.Models;
using Microsoft.EntityFrameworkCore;

public static class Endpoints
{
    const string EndpointName = "GetCompany";

    public static void MapCompanyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/companies");

        group.MapGet("/", async (CompanyAdminPanelContext dbContext)
            => await dbContext.Companies
                    .Select(company => new CompanyDto(
                        company.Id,
                        company.Name ?? string.Empty,
                        company.Email ?? string.Empty,
                        company.Logo ?? string.Empty,
                        company.Website ?? string.Empty
            )).AsNoTracking().ToListAsync());
        
        group.MapGet("/{id}", async (int id, CompanyAdminPanelContext dbContext) =>
        {
            var company = await dbContext.Companies.FindAsync(id);

            return company is null ? Results.NotFound(company) : Results.Ok(
                new CompanyDetailsDto(
                    company.Id,
                    company.Name ?? string.Empty,
                    company.Email ?? string.Empty,
                    company.Logo ?? string.Empty,
                    company.Website ?? string.Empty
                )
            );
        }).WithName(EndpointName);
    }
}