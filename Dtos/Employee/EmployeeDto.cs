namespace CompanyAdminPanel.Dtos.Employee;

using CompanyAdminPanel.Models;

public record class EmployeeDto
(
    int Id,
    string FirstName,
    string LastName,
    int CompanyId,
    string Email,
    int Phone
);