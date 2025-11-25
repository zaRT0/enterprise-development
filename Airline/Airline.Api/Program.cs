using Airline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Airline.Dtos;
using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0))
    ));

builder.Services.AddScoped(typeof(IRepository<Flight>), typeof(FlightRepository));
builder.Services.AddScoped(typeof(IRepository<AircraftFamily>), typeof(AircraftFamilyRepository));
builder.Services.AddScoped(typeof(IRepository<AircraftModel>), typeof(AircraftModelRepository));
builder.Services.AddScoped(typeof(IRepository<Passenger>), typeof(PassengerRepository));
builder.Services.AddScoped(typeof(IRepository<Ticket>), typeof(TicketRepository));

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.UseInlineDefinitionsForEnums();
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airline");
});

app.UseAuthorization();

app.MapControllers();

app.Run();