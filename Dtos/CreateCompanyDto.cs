namespace CompanyAdminPanel.Dtos;

public record class CreateCompanyDto
(
    string Name,
    string Email,
    string Logo,
    string Website    
);