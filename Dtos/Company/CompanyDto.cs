namespace CompanyAdminPanel.Dtos.Company;

public record class CompanyDto
(
    int Id,
    string Name,
    string Email,
    string Logo,
    string Website    
);