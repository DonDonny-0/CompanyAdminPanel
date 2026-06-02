namespace CompanyAdminPanel.Dtos.Employee;

public record class UpdateEmployeeDto
(
    string FirstName,
    string LastName,
    string Company,
    string Email,
    int Phone   
);