namespace CompanyAdminPanel.Dtos;

public record class EmployeeDto
(
    int Id,
    string FirstName,
    string LastName,
    string Company,
    string Email,
    int Phone
);