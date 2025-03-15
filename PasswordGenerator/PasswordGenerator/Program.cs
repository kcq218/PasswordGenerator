using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordGenerator.DAL;
using PasswordGenerator.Model;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IDbContext, DbAll01ProdUswest001Context>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<PasswordGenerator.Model.PasswordGenerator>, Repository<PasswordGenerator.Model.PasswordGenerator>>();
using IHost host = builder.Build();

await host.RunAsync();