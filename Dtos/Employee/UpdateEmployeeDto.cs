namespace CompanyAdminPanel.Dtos.Employee;

public record class UpdateEmployeeDto
(
    string FirstName,
    string LastName,
    int CompanyId,
    string Email,
    int Phone   
);