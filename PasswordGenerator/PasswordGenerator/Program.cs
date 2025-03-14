using Microsoft.Extensions.Hosting;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

using IHost host = builder.Build();


await host.RunAsync();