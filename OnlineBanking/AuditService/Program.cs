using AuditService;
using AuditService.MQ;
using Microsoft.EntityFrameworkCore;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AuditServiceDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AuditServiceDB")));
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
builder.Services.AddHttpClient("errorApi", c => { c.BaseAddress = new Uri("http://localhost:5047"); })
            .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(2, TimeSpan.FromMinutes(2)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
