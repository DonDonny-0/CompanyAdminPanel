using CompanyAdminPanel.Data;
using CompanyAdminPanel.Endpoints;


var builder = WebApplication.CreateBuilder(args);

var connString = "Data Source=CompanyAdminPanel.db";
builder.Services.AddSqlite<CompanyAdminPanelContext>(connString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("ReactFrontend");

app.MigrateDb();
app.SeedCompanies(10);

app.MapCompanyEndpoints();
app.MapEmployeeEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
