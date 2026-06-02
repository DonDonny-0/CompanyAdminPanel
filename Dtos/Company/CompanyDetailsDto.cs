namespace CompanyAdminPanel.Dtos.Company;

public record class CompanyDetailsDto
(
    int Id,
    string Name,
    string Email,
    string Logo,
    string Website    
);