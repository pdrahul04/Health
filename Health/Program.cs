using Health.Application.Commands.Plan;
using Health.Domain.Interfaces.Repositories;
using Health.Infrastructure.Data;
using Health.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
#region Database Configuration
builder.Services.AddDbContext<HealthDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null);
            sqlOptions.CommandTimeout(30);
        });
});
#endregion
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Repository Registration
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
#endregion

#region MediatR Configuration
// Register MediatR from Application assembly (where handlers are located)
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreatePlanHandler>();
});
#endregion
#region AutoMapper Configuration
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PlanMappingProfile>();
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
