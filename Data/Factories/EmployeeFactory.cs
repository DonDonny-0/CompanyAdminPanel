using Bogus;
using CompanyAdminPanel.Models;

namespace CompanyAdminPanel.Data.Factories;

public static class EmployeeFactory
{
    public static Faker<Employee> CreateFaker(Company? company = null)
        => new Faker<Employee>()
            .StrictMode(false)
            .RuleFor(e => e.FirstName, f => f.Name.FirstName())
            .RuleFor(e => e.LastName, f => f.Name.LastName())
            .RuleFor(e => e.Company, f => company)
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
            .RuleFor(e => e.Phone, f => f.Phone.PhoneNumber()?.GetHashCode() ?? 0);

    public static IEnumerable<Employee> GenerateEmployeeData(IEnumerable<Company> companies)
    {
        var companiesList = companies.ToList();
        var employees = new List<Employee>();
        const int totalEmployees = 100;

        for (int i = 0; i < totalEmployees; i++)
        {
            var company = companiesList[i % companiesList.Count];
            var employee = CreateFaker(company).Generate();
            employees.Add(employee);
        }

        return employees;
    }
}