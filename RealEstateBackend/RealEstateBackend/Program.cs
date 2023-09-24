using Microsoft.EntityFrameworkCore;
using RealEstateBackend.Amenities.Models;
using RealEstateBackend.Amenities.Repository;
using RealEstateBackend.EF;
using RealEstateBackend.EF.Interfaces;
using RealEstateBackend.RealEstateTypes.Models;
using RealEstateBackend.RealEstateTypes.Repositories;
using Serilog;
using Steeltoe.Management.Endpoint;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Amenity>, AmenitiesRepository>();
builder.Services.AddScoped<IRepository<RealEstateKind>, RealEstateKindsRepository>();

builder.Services.AddDbContext<RealEstateContext>(service =>
{
    service.UseNpgsql(builder.Configuration.GetConnectionString("RealEstateProject"));
});

var app = builder.AddAllActuators().Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
