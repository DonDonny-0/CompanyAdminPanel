using Bogus;
using CompanyAdminPanel.Models;

namespace CompanyAdminPanel.Data.Factories;

public static class CompanyFactory
{
    public static Faker<Company> CreateFaker()
        => new Faker<Company>()
            .StrictMode(false)
            .RuleFor(c => c.Name, f => f.Company.CompanyName())
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name ?? "company"))
            .RuleFor(c => c.Logo, f => f.Image.PicsumUrl(width: 200, height: 200))
            .RuleFor(c => c.Website, f => f.Internet.Url());

    public static IEnumerable<Company> GenerateCompanyData(int count = 10)
        => CreateFaker().Generate(count);
}

