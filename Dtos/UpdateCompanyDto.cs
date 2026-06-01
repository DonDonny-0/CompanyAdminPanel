namespace CompanyAdminPanel.Dtos;

public record class UpdateCompanyDto
(
    string Name,
    string Email,
    string Logo,
    string Website    
);