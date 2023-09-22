using AutoMapper;
using CarModelExplorer.Core.Entities;
using CarModelExplorer.Core.Interfaces;
using CarModelExplorer.Core.Mappings;
using CarModelExplorer.Core.Services;
using CarModelExplorer.Infra.Data;
using CarModelExplorer.Infra.Repositories;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<ICarMake, CarMakeService>();
        builder.Services.AddScoped<ICarMakeRepo, CarMakeRepo>();

        builder.Services.AddDbContext<CarDbContext>(options =>
          options.UseInMemoryDatabase("MyInMemoryDatabase"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<CarDbContext>();

            // Path to your CSV file
            var csvFilePath = "CarMake.csv"; // Replace with the actual path to your CSV file

            // Initialize the database from the CSV file
            dbContext.InitializeFromCsvFile(csvFilePath);
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}