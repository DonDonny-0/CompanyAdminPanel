namespace CompanyAdminPanel.Dtos.Company;

public record class UpdateCompanyDto
(
    string Name,
    string Email,
    string Logo,
    string Website    
);