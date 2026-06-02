namespace CompanyAdminPanel.Endpoints;

using CompanyAdminPanel.Data;
using CompanyAdminPanel.Dtos.Company;
using CompanyAdminPanel.Models;
using Microsoft.EntityFrameworkCore;

public static class CompaniesEndpoints
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

        group.MapPost("/", async (CreateCompanyDto newCompany, CompanyAdminPanelContext dbContext) =>
        {
            Company company = new()
            {
                Name = newCompany.Name,
                Email = newCompany.Email,
                Logo = newCompany.Logo,
                Website = newCompany.Website,
            };

            dbContext.Companies.Add(company);
            await dbContext.SaveChangesAsync();

            CompanyDetailsDto companyDto = new (
                company.Id,
                company.Name,
                company.Email,
                company.Logo,
                company.Website
            );

            return Results.CreatedAtRoute(EndpointName, new {id = companyDto.Id}, companyDto);
        }).WithName("CreateCompany");

        group.MapPut("/{id}", async (int id, UpdateCompanyDto updatedCompany, CompanyAdminPanelContext dbContext) => {
            
            var existingCompany = await dbContext.Companies.FindAsync(id);

            if (existingCompany is null)
            {
                return Results.NotFound();
            }

            existingCompany.Name = updatedCompany.Name;
            existingCompany.Email = updatedCompany.Email;
            existingCompany.Logo = updatedCompany.Logo;
            existingCompany.Website = updatedCompany.Website;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        }).WithName("UpdateCompany");

        group.MapDelete("/{id}", async (int id, CompanyAdminPanelContext dbContext) =>
        {
            await dbContext.Companies.Where(company => company.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });
    }
}