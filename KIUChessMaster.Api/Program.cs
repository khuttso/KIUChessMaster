using Microsoft.AspNetCore.Authentication.Negotiate;
using KIUChessMaster.Infrastructure.Persistence;
using KIUChessMaster.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using KIUChessMaster.Application;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // 🚀 Needed for controllers

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("LocalConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("LocalConnection"))
    ));

builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddEventSourceLogger();
builder.Logging.AddFilter("Microsoft", LogLevel.Information)
    .AddFilter("KIUChessMaster", LogLevel.Debug);

// Register MediatR - scan Application project for handlers
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("KIUChessMaster.Application")));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(KIUChessMaster.Application.AssemblyMarker).Assembly));

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("🚀 Application started at {time}", DateTime.UtcNow);

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // 🚀 Now works because AddControllers() is registered

app.Run();