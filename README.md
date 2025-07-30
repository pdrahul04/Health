# Health


🏥 Health Insurance Management System
A comprehensive Health Insurance Management API built with Clean Architecture, CQRS Pattern, and Domain-Driven Design principles using ASP.NET Core and Entity Framework Core.
📋 Table of Contents

Overview
Architecture
Features
Technology Stack
Project Structure
Getting Started
API Documentation
Database Schema
Business Rules
Testing
Deployment
Contributing
License

🎯 Overview
The Health Insurance Management System is a modern, scalable API that manages health insurance operations including member enrollment, plan management, and claims processing. Built with industry-standard patterns and practices, it provides a robust foundation for insurance companies and healthcare organizations.
Key Capabilities

Member Management - Complete lifecycle from enrollment to termination
Plan Administration - Flexible insurance plan configuration and management
Claims Processing - End-to-end claims workflow from submission to payment
Business Rules Engine - Automated eligibility checks and premium calculations
Audit Trail - Complete tracking of all system changes

🏗️ Architecture
This system implements Clean Architecture with clear separation of concerns:
┌─────────────────────────────────────────────┐
│                   API Layer                 │ ← Controllers, Middleware
├─────────────────────────────────────────────┤
│              Application Layer              │ ← CQRS, DTOs, Validators
├─────────────────────────────────────────────┤
│                Domain Layer                 │ ← Entities, Business Rules
├─────────────────────────────────────────────┤
│            Infrastructure Layer             │ ← Data Access, External APIs
└─────────────────────────────────────────────┘
CQRS Implementation

Commands - Write operations (Create, Update, Delete)
Queries - Read operations (Get, Search, Filter)
Handlers - Business logic execution
MediatR - Request/response pipeline management

✨ Features
👥 Member Management

✅ Member registration and enrollment
✅ Plan assignment and changes
✅ Eligibility verification
✅ Premium calculation based on age and plan
✅ Member status management (Active/Inactive)
✅ Duplicate email prevention

📋 Plan Administration

✅ Insurance plan creation and configuration
✅ Coverage percentage and deductible management
✅ Premium and copay settings
✅ Plan activation/deactivation
✅ Member enrollment capacity tracking

🏥 Claims Processing

✅ Claim submission with automatic numbering
✅ Multi-stage approval workflow
✅ Coverage calculation based on plan rules
✅ Rejection handling with reason tracking
✅ Payment processing and status updates
✅ Claims history and reporting

🔧 System Features

✅ Comprehensive input validation
✅ Automatic API documentation (Swagger)
✅ Structured error handling
✅ Database migrations and seeding
✅ Logging and monitoring ready
✅ CORS configuration for web clients

🛠️ Technology Stack
Backend

ASP.NET Core 8.0 - Web API framework
Entity Framework Core - ORM and database access
MediatR - CQRS implementation and request handling
FluentValidation - Input validation framework
SQL Server - Primary database
Swagger/OpenAPI - API documentation

Development Tools

Visual Studio 2022 or VS Code
.NET 8 SDK
SQL Server LocalDB (for development)
Postman (for API testing)

📁 Project Structure
HealthInsurance/
├── 🎯 HealthInsurance.Domain/           # Core business logic
│   ├── Entities/                       # Domain entities
│   │   ├── Member.cs
│   │   ├── Plan.cs
│   │   └── Claim.cs
│   └── Interfaces/                     # Repository contracts
│       ├── IRepository.cs
│       ├── IMemberRepository.cs
│       ├── IPlanRepository.cs
│       └── IClaimRepository.cs
│
├── 📱 HealthInsurance.Application/      # Use cases & DTOs
│   ├── DTOs/                          # Data transfer objects
│   ├── Commands/                      # Write operations
│   ├── Queries/                       # Read operations
│   ├── Handlers/                      # Business logic handlers
│   └── Validators/                    # Input validation rules
│
├── 🏛️ HealthInsurance.Infrastructure/   # Data access
│   ├── Data/                         # DbContext and configuration
│   └── Repositories/                 # Repository implementations
│
└── 🌐 HealthInsurance.API/             # Web API
    ├── Controllers/                   # REST API endpoints
    ├── Program.cs                     # Application startup
    └── appsettings.json              # Configuration
🚀 Getting Started
Prerequisites

.NET 8 SDK or later
SQL Server (LocalDB for development)
Visual Studio 2022 or VS Code (recommended)
Git for version control

Installation

Clone the repository
bashgit clone https://github.com/your-org/health-api.git
cd health-api

Create the solution structure
bash# Create solution
dotnet new sln -n Health

# Create projects
dotnet new classlib -n HealthInsurance.Domain
dotnet new classlib -n HealthInsurance.Application  
dotnet new classlib -n HealthInsurance.Infrastructure
dotnet new webapi -n Health.API

# Add projects to solution
dotnet sln add Health.Domain
dotnet sln add Health.Application
dotnet sln add Health.Infrastructure
dotnet sln add Health.API

Add NuGet packages
bash# Application layer
cd HealthInsurance.Application
dotnet add package MediatR
dotnet add package FluentValidation
dotnet add reference ../HealthInsurance.Domain

# Infrastructure layer
cd ../Health.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add reference ../Health.Domain

# API layer
cd ../Health.API
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package MediatR
dotnet add package FluentValidation.AspNetCore
dotnet add package Swashbuckle.AspNetCore
dotnet add reference ../Health.Application
dotnet add reference ../Health.Infrastructure

Configure the database connection
Update appsettings.json in the API project:
json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HealthInsuranceDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}

Build and run the application
bashcd Health.API
dotnet build
dotnet run

Access the API

Swagger UI: https://localhost:7xxx/swagger
API Base URL: https://localhost:7xxx/api



Quick Test
Once running, you can quickly test the API:
bash# Get all insurance plans
curl -X GET "https://localhost:7xxx/api/plans" -H "accept: application/json"

# Create a new member
curl -X POST "https://localhost:7xxx/api/members" \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "John",
    "lastName": "Doe", 
    "dateOfBirth": "1990-01-15",
    "email": "john.doe@email.com",
    "phoneNumber": "555-0123",
    "address": "123 Main St, City, State",
    "planId": 1
  }'
📚 API Documentation
Base URL
https://localhost:7xxx/api
Authentication
Currently, the API does not require authentication. In production, implement JWT or OAuth2.
Members Endpoints
MethodEndpointDescriptionGET/membersGet all membersGET/members/{id}Get member by IDGET/members/by-plan/{planId}Get members by planPOST/membersCreate new memberPUT/members/{id}Update memberDELETE/members/{id}Delete member
Plans Endpoints
MethodEndpointDescriptionGET/plansGet all plansGET/plans/activeGet active plans onlyGET/plans/{id}Get plan by IDPOST/plansCreate new planPUT/plans/{id}Update planDELETE/plans/{id}Delete plan
Claims Endpoints
MethodEndpointDescriptionGET/claimsGet all claimsGET/claims/{id}Get claim by IDGET/claims/member/{memberId}Get claims by memberGET/claims/status/{status}Get claims by statusPOST/claimsSubmit new claimPUT/claims/{id}/processProcess claim (approve/reject)PUT/claims/{id}/payMark claim as paid
Sample Requests
Create Member
jsonPOST /api/members
{
  "firstName": "Jane",
  "lastName": "Smith",
  "dateOfBirth": "1985-03-20",
  "email": "jane.smith@email.com",
  "phoneNumber": "555-0456",
  "address": "456 Oak Ave, City, State",
  "planId": 2
}
Create Insurance Plan
jsonPOST /api/plans
{
  "name": "Gold Plan",
  "description": "Premium coverage with low deductibles",
  "basePremium": 350.00,
  "deductible": 500.00,
  "copayAmount": 10.00,
  "outOfPocketMax": 2500.00,
  "coveragePercentage": 90
}
Submit Claim
jsonPOST /api/claims
{
  "memberId": 1,
  "amount": 1500.00,
  "serviceDate": "2024-01-15",
  "description": "Annual physical examination and blood work",
  "providerName": "City Medical Center"
}
Process Claim
jsonPUT /api/claims/1/process
{
  "isApproved": true,
  "approvedAmount": 1200.00,
  "rejectionReason": null
}
🗄️ Database Schema
Members Table
ColumnTypeDescriptionIdint (PK)Unique identifierFirstNamenvarchar(50)Member's first nameLastNamenvarchar(50)Member's last nameDateOfBirthdatetime2Birth dateEmailnvarchar(100)Email (unique)PhoneNumbernvarchar(20)Contact numberAddressnvarchar(200)Home addressEnrollmentDatedatetime2Enrollment dateIsActivebitActive statusPlanIdint (FK)Reference to Plans
Plans Table
ColumnTypeDescriptionIdint (PK)Unique identifierNamenvarchar(100)Plan nameDescriptionnvarchar(500)Plan descriptionBasePremiumdecimal(10,2)Base monthly premiumDeductibledecimal(10,2)Annual deductibleCopayAmountdecimal(10,2)Copay per visitOutOfPocketMaxdecimal(10,2)Annual out-of-pocket maximumCoveragePercentageintCoverage percentageIsActivebitActive statusCreatedDatedatetime2Creation date
Claims Table
ColumnTypeDescriptionIdint (PK)Unique identifierMemberIdint (FK)Reference to MembersClaimNumbernvarchar(20)Unique claim numberAmountdecimal(10,2)Claim amountServiceDatedatetime2Date of serviceSubmissionDatedatetime2Submission dateStatusintClaim status (enum)Descriptionnvarchar(500)Service descriptionProviderNamenvarchar(100)Healthcare providerApprovedAmountdecimal(10,2)Approved amountRejectionReasonnvarchar(500)Rejection reasonProcessedDatedatetime2Processing date
Relationships

Members → Plans (Many-to-One)
Claims → Members (Many-to-One)

⚖️ Business Rules
Member Eligibility

Must be between 18-65 years old
Email addresses must be unique
Members can only be enrolled in active plans
Premium calculation varies by age:

Under 30: Base premium × 1.0
30-39: Base premium × 1.2
40-49: Base premium × 1.5
50+: Base premium × 2.0



Plan Management

Plans can be deactivated but not deleted if members are enrolled
Coverage percentage must be between 0-100%
Deductible must be less than out-of-pocket maximum

Claims Processing

Claims can only be submitted for active members
Claim numbers are auto-generated (CLM{YEAR}{NUMBER})
Status progression: Submitted → Under Review → Approved/Rejected → Paid
Only approved claims can be marked as paid
Approved/paid claims cannot be rejected

Coverage Calculation
If (TotalCost <= Deductible)
    CoveredAmount = 0
Else
    EligibleAmount = TotalCost - Deductible
    CoveredAmount = EligibleAmount × (CoveragePercentage / 100)
🧪 Testing
Unit Testing
bash# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
Integration Testing
bash# Test specific endpoints
dotnet test --filter "Category=Integration"
Manual Testing with Swagger

Navigate to https://localhost:7xxx/swagger
Expand endpoint categories
Click "Try it out" on any endpoint
Fill in parameters and click "Execute"

Sample Test Data
The system includes seed data for immediate testing:

3 Insurance Plans (Basic, Premium, Family)
Sample Members can be created via API
Claims can be submitted and processed

🚀 Deployment
Development Environment
bashdotnet run --environment Development
Production Deployment

Configure Production Database
json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=prod-server;Database=HealthInsurance;User Id=app-user;Password=secure-password;TrustServerCertificate=true"
  }
}

Publish Application
bashdotnet publish -c Release -o ./publish

Deploy to IIS/Azure/AWS

Copy published files to server
Configure application pool
Set up SSL certificate
Configure environment variables



Environment Variables
bashASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection=<production-db-connection>
Health Checks
The API includes health check endpoints:

/health - Basic health check
/health/db - Database connectivity check

📊 Monitoring and Logging
Application Insights (Azure)
json{
  "ApplicationInsights": {
    "InstrumentationKey": "your-key-here"
  }
}
Structured Logging
csharp_logger.LogInformation("Member {MemberId} enrolled in plan {PlanId}", 
    member.Id, member.PlanId);
Performance Metrics

Response time monitoring
Database query performance
Memory and CPU usage
Error rate tracking

🔒 Security Considerations
Current Implementation

Input validation with FluentValidation
SQL injection prevention via EF Core
CORS configuration for web clients

Recommended Enhancements

Authentication: JWT tokens or OAuth2
Authorization: Role-based access control
Rate Limiting: Prevent API abuse
Data Encryption: Sensitive data at rest
Audit Logging: Track all data changes
HTTPS Only: Force secure connections

Sample JWT Implementation
csharpservices.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });
🔧 Configuration
Development Settings
json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HealthInsuranceDb;Trusted_Connection=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Warning"
    }
  }
}
Production Settings
json{
  "ConnectionStrings": {
    "DefaultConnection": "Production connection string"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "yourdomain.com"
}
📈 Performance Optimization
Database Optimization

Use Include() for navigation properties
Implement pagination for large result sets
Add database indexes on frequently queried columns
Consider read replicas for reporting

Caching Strategy
csharpservices.AddMemoryCache();
services.AddStackExchangeRedisCache(options => {
    options.Configuration = "localhost:6379";
});
API Performance

Enable response compression
Implement API versioning
Use async/await consistently
Consider GraphQL for complex queries

🤝 Contributing
Development Workflow

Fork the repository
Create a feature branch (git checkout -b feature/amazing-feature)
Commit changes (git commit -m 'Add amazing feature')
Push to branch (git push origin feature/amazing-feature)
Open a Pull Request

Code Standards

Follow C# naming conventions
Write unit tests for new features
Update documentation for API changes
Ensure all tests pass before submitting

Commit Message Format
type(scope): description

[optional body]

[optional footer]
Types: feat, fix, docs, style, refactor, test, chore
📄 License
This project is licensed under the MIT License - see the LICENSE file for details.
🆘 Support
Getting Help

Documentation: Check this README and inline code comments
Issues: Create a GitHub issue for bugs or feature requests
Discussions: Use GitHub Discussions for questions

Common Issues
Database Connection Failed
bash# Update connection string in appsettings.json
# Ensure SQL Server is running
# Check firewall settings
Build Errors
bash# Restore NuGet packages
dotnet restore

# Clean and rebuild
dotnet clean
dotnet build
Migration Issues
bash# Create new migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
