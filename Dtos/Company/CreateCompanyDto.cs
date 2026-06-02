namespace CompanyAdminPanel.Dtos.Company;

public record class CreateCompanyDto
(
    string Name,
    string Email,
    string Logo,
    string Website    
);