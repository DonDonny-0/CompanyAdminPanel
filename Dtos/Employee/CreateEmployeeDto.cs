namespace CompanyAdminPanel.Dtos.Employee;

public record class CreateEmployeeDto
(
    string FirstName,
    string LastName,
    string Company,
    string Email,
    int Phone  
);