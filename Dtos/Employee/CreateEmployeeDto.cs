namespace CompanyAdminPanel.Dtos.Employee;

using CompanyAdminPanel.Models;

public record class CreateEmployeeDto
(
    string FirstName,
    string LastName,
    int CompanyId,
    string Email,
    int Phone  
);