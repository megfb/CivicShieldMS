using CivicShieldMS.AuthService.Api;
using CivicShieldMS.Shared.EventBus.EventBus;
using CivicShieldMS.Shared.EventBus.Extensions;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment; // BU SATIR GEREKLÝ

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSharedEventBus(new[] { typeof(Program).Assembly }, builder.Environment);
builder.Services.AddMassTransit(cfg =>
{
    cfg.ConfigureEventBus(environment, new[] { typeof(TestIntegrationEventHandler).Assembly }, (busFactoryCfg, context) =>
    {
        busFactoryCfg.ReceiveEndpoint("b-service-queue", e =>
        {
            e.ConfigureConsumer<TestIntegrationEventHandler>(context);

            e.Bind("a-service-event", s =>
            {
                s.RoutingKey = "test-integration-event";
                s.ExchangeType = "topic";
            });
        });
    });
});


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
