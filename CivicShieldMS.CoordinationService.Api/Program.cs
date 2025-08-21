using System.Reflection;
using CivicShieldMS.CoordinationService.Api.Domain.Repositories.Abstractions;
using CivicShieldMS.CoordinationService.Api.Domain.Repositories.EntityFramework;
using CivicShieldMS.CoordinationService.Api.Domain.Repositories.EntityFramework.DbContexts;
using CivicShieldMS.Shared.Common.Domain;
using CivicShieldMS.Shared.EventBus.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSharedEventBus(new[] { typeof(Program).Assembly }, builder.Environment);
builder.Services.AddScoped<ISupporterRepository, SupporterRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<CoordinationDbContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

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
