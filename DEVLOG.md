# Project Devlog / Brandon Thomas Murray

## 01/06/2026 - Monday
### Notes
- Dtos for Company and Employee
- Model for Company
- implemented Dtos for companies
- made endpoints for getting all companies and a single company
- made a factory for generating fake companies.
- EntityFrameworkCore implemented for Sqlite, will move to MySQL later.

### Files added/changed:
- __*Data*__
    - __*Factories*__
        - CompanyFactory.cs
    - CompanyAdminPanelContext.cs
    - DataExtensions.cs
- __*Dtos*__
    - CompanyDetailsDto.cs
    - CreateCompanyDto.cs
    - UpdateCompanyDto.cs
    - CompanyDto.cs
- __*Endpoints*__
    - CompaniesEndpoints.cs
- __*Models*__
    - Company.cs

### Next Steps
- Employee Dtos for GET POST and UPDATE
- Endpoints for Employee requests
- Migrations and Factories for Employees
- API Testing

## 02/06/2026 - Tuesday

### Notes
- Added Dtos for all employee requests
- Organised Employee and Company Dtos into directories
- Added API Endpoints for Employees (GET all, GET single)
- Made a Data Model for Employees.
- Made an Employee Factory which generates fake employee data.
- All API endpoints for Companies and Employees are fully implemented (GET, POST, PUT, DELETE)

### Files added/changed:
- __*Data*__
    - __*Factories*__
        - Employeeactory.cs
    - CompanyAdminPanelContext.cs
    - DataExtensions.cs
- __*Dtos*__
    - __*Company*__
        - CompanyDetailsDto.cs
        - CreateCompanyDto.cs
        - UpdateCompanyDto.cs
        - CompanyDto.cs
    - __*Employee*__
        - EmployeeDetailsDto.cs
        - CreateEmployeeDto.cs
        - UpdateEmployeeDto.cs
        - EmployeeDto.cs
- __*Endpoints*__
    - EmployeeEndpoints.cs
- __*Models*__
    - Employee.cs
- Program.cs

### Next Steps
- Setup initial Frontend
- create forms to consume API (POST, PUT)
- Create Views for Companies and Employees

## 03/06/2026 - Wednesday

### Notes