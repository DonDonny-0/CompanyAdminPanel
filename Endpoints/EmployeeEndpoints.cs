namespace CompanyAdminPanel.Endpoints;

using CompanyAdminPanel.Data;
using CompanyAdminPanel.Dtos.Company;
using CompanyAdminPanel.Dtos.Employee;
using CompanyAdminPanel.Models;
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
                        employee.CompanyId,
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
                    employee.CompanyId!,
                    employee.Email ?? string.Empty,
                    employee.Phone
                )
            );
        }).WithName(EndpointName);

        group.MapPost("/", async (CreateEmployeeDto newEmployee, CompanyAdminPanelContext dbContext) =>
        {
            var company = await dbContext.Companies.FindAsync(newEmployee.CompanyId);
            if (company is null)
            {
                return Results.BadRequest(new { error = "Company not found." });
            }

            Employee employee = new()
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Company = company,
                CompanyId = newEmployee.CompanyId,
                Email = newEmployee.Email,
                Phone = newEmployee.Phone
            };

            dbContext.Employees.Add(employee);
            await dbContext.SaveChangesAsync();

            EmployeeDetailsDto employeeDto = new (
                employee.Id,
                employee.FirstName,
                employee.LastName,
                employee.CompanyId,
                employee.Email,
                employee.Phone
            );

            return Results.CreatedAtRoute(EndpointName, new {id = employeeDto.Id}, employeeDto);
        }).WithName("CreateEmployee");

        group.MapPut("/{id}", async (int id, UpdateEmployeeDto updatedEmployee, CompanyAdminPanelContext dbContext) => {
            
            var existingEmployee = await dbContext.Employees.FindAsync(id);

            if (existingEmployee is null)
            {
                return Results.NotFound();
            }

            existingEmployee.FirstName = updatedEmployee.FirstName;
            existingEmployee.LastName = updatedEmployee.LastName;
            existingEmployee.CompanyId = updatedEmployee.CompanyId;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.Phone = updatedEmployee.Phone;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        }).WithName("UpdateEmployee");

        group.MapDelete("/{id}", async (int id, CompanyAdminPanelContext dbContext) =>
        {
            await dbContext.Employees.Where(employee => employee.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });
    }
}