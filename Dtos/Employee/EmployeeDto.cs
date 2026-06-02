namespace CompanyAdminPanel.Dtos.Employee;

using CompanyAdminPanel.Models;

public record class EmployeeDto
(
    int Id,
    string FirstName,
    string LastName,
    Company Company,
    string Email,
    int Phone
);