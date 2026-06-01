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

    public static void SeedCompanies(this WebApplication app, int count = 10)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CompanyAdminPanelContext>();

        if (dbContext.Companies.Any())
        {
            return;
        }

        var companies = CompanyFactory.GenerateCompanyData(count).ToArray();
        dbContext.Companies.AddRange(companies);
        dbContext.SaveChanges();
    }
}