using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordGenerator.DAL;
using PasswordGenerator.Model;
using PasswordGenerator.Services;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IDbContext, DbAll01ProdUswest001Context>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<PasswordGenerator.Model.PasswordGenerator>, Repository<PasswordGenerator.Model.PasswordGenerator>>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

using IHost host = builder.Build();
var programLoop = true;

while (programLoop)
{
    IPasswordService passwordService = builder.Services.BuildServiceProvider().GetRequiredService<IPasswordService>();
    var options = new List<AbstractOption>();
    var uppercase = new UpperCaseChars();
    var lowercase = new LowerCaseChars();
    var numbers = new Numbers();
    var symbols = new Symbols();


    Console.WriteLine("Please enter length of Password");
    var length = Console.ReadLine();

    while (!length.All(char.IsDigit) || Convert.ToInt32(length) < Constants.NumberOfRules || Convert.ToInt32(length) > Constants.MaxLength)
    {
        Console.WriteLine("Please enter a real number between 4 and 50");
        length = Console.ReadLine();
    }

    while (!symbols.Included && !uppercase.Included && !lowercase.Included && !numbers.Included)
    {
        Console.WriteLine("Please enter y for at least one of the following options");
        Console.WriteLine("Enter y if you want uppercase");
        uppercase.Included = Console.ReadLine().ToLower() == "y";
        Console.WriteLine("Enter y if you want lowerCase");
        lowercase.Included = Console.ReadLine().ToLower() == "y";
        Console.WriteLine("Enter y if you want numbers");
        numbers.Included = Console.ReadLine().ToLower() == "y";
        Console.WriteLine("Enter y if you want symbols");
        symbols.Included = Console.ReadLine().ToLower() == "y";
    }

    options.Add(uppercase);
    options.Add(lowercase);
    options.Add(numbers);
    options.Add(symbols);

    var result = await passwordService.Generate(Convert.ToInt32(length), options);
    Console.WriteLine("Here is the result: " + result);
    Console.WriteLine("Do you want to continue, press q to quit");
    programLoop = Console.ReadLine().ToLower() != "q";
}

await host.RunAsync();

