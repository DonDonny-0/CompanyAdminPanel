namespace CompanyAdminPanel.Endpoints;

using CompanyAdminPanel.Data;
using CompanyAdminPanel.Dtos.Employee;
// using CompanyAdminPanel.Models;
using Microsoft.EntityFrameworkCore;

public static class EmployeesEndpoints
{
    const string EndpointName = "GetEmployee";

    public static void MapEmployeeEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/employees");

        group.MapGet("/", async (CompanyAdminPanelContext dbContext)
            => await dbContext.Employees
                    .Select(employee => new EmployeeDto(
                        employee.Id,
                        employee.FirstName ?? string.Empty,
                        employee.LastName ?? string.Empty,
                        employee.Company!,
                        employee.Email ?? string.Empty,
                        employee.Phone
            )).AsNoTracking().ToListAsync());

        group.MapGet("/{id}", async (int id, CompanyAdminPanelContext dbContext) =>
        {
            var employee = await dbContext.Employees
                .Include(e => e.Company)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee is null)
                return Results.NotFound();

            return Results.Ok(
                new EmployeeDetailsDto(
                    employee.Id,
                    employee.FirstName ?? string.Empty,
                    employee.LastName ?? string.Empty,
                        employee.Company!,
                    employee.Email ?? string.Empty,
                    employee.Phone
                )
            );
        }).WithName(EndpointName);
    }
}