using CompanyAdminPanel.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAdminPanel.Data;

public class CompanyAdminPanelContext
    (DbContextOptions<CompanyAdminPanelContext> options) : DbContext(options)
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Employee> Employees => Set<Employee>();
}