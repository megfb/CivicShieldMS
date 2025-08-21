using System.Reflection;
using CivicShield.IncidentService.Api.Domain.Repositories;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.EntityFramework;
using CivicShieldMS.IncidentService.Api.Domain.Repositories.EntityFramework.DbContexts;
using CivicShieldMS.Shared.Common.Domain;
using CivicShieldMS.Shared.EventBus.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IncidentDbContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")));
builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddSharedEventBus(new[] { typeof(Program).Assembly }, builder.Environment);
var env = builder.Environment.EnvironmentName;
Console.WriteLine($"### ENVIRONMENT: {env} ###");

var rabbitHost = builder.Configuration["RabbitMqSettings:Host"];
Console.WriteLine($"### RABBITMQ HOST: {rabbitHost} ###");
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IncidentService V1");
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
