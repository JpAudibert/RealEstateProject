using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealEstateBackend.Infrastructure.Amenities.Models;
using RealEstateBackend.Infrastructure.Amenities.Repositories;
using RealEstateBackend.Infrastructure.EF;
using RealEstateBackend.Infrastructure.EF.Interfaces;
using RealEstateBackend.Infrastructure.RealEstateKinds.Models;
using RealEstateBackend.Infrastructure.RealEstateKinds.Repositories;
using RealEstateBackend.Services.Auth;
using Serilog;
using Steeltoe.Management.Endpoint;
using System.Text;

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

var key = Encoding.ASCII.GetBytes(Key.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

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


