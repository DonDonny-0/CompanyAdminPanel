using CompanyAdminPanel.Data.Factories;
using Microsoft.EntityFrameworkCore;

namespace CompanyAdminPanel.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CompanyAdminPanelContext>();
        dbContext.Database.Migrate();
    }

    public async static void SeedCompanies(this WebApplication app, int count = 10)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CompanyAdminPanelContext>();

        if (dbContext.Companies.Any())
        {
            return;
        }

        var companies = CompanyFactory.GenerateCompanyData(10).ToList();
        var employees = EmployeeFactory.GenerateEmployeeData(companies);

        // Then add to your database context
        dbContext.Companies.AddRange(companies);
        dbContext.Employees.AddRange(employees);
        await dbContext.SaveChangesAsync();
    }
}