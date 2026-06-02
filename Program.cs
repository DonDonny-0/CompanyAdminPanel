using CompanyAdminPanel.Data;
using CompanyAdminPanel.Endpoints;


var builder = WebApplication.CreateBuilder(args);

var connString = "Data Source=CompanyAdminPanel.db";
builder.Services.AddSqlite<CompanyAdminPanelContext>(connString);

var app = builder.Build();

app.MigrateDb();
app.SeedCompanies(10);

app.MapCompanyEndpoints();
app.MapEmployeeEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
