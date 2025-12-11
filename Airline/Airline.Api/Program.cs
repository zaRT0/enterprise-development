using Airline.Api.Kafka;
using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Dtos;
using Airline.Infrastructure.Persistence;
using Airline.Infrastructure.Repositories;
using Airline.ServiceDefaults;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 0, 0))
    ));

builder.Services.AddScoped<IRepository<Flight>, FlightRepository>();
builder.Services.AddScoped<IRepository<AircraftFamily>, AircraftFamilyRepository>();
builder.Services.AddScoped<IRepository<AircraftModel>, AircraftModelRepository>();
builder.Services.AddScoped<IRepository<Passenger>, PassengerRepository>();
builder.Services.AddScoped<IRepository<Ticket>, TicketRepository>();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());

var kafkaConnection = builder.Configuration.GetConnectionString("KafkaConnection") ??  throw new InvalidOperationException(
        "Connection string 'KafkaConnection' is missing in 'ConnectionStrings'.");

builder.Services.Configure<KafkaOptions>(builder.Configuration.GetSection("Kafka"));

builder.Services.AddSingleton(sp =>
{
    var options = sp.GetRequiredService<IOptions<KafkaOptions>>().Value;
    var config = new ConsumerConfig
    {
        BootstrapServers = kafkaConnection,
        GroupId = options.ConsumerGroup,
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = false
    };
    return new ConsumerBuilder<Ignore, string>(config).Build();
});

builder.Services.AddHostedService<KafkaConsumer>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var basePath = AppContext.BaseDirectory;

    var xmlApi = Path.Combine(basePath, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
    c.IncludeXmlComments(xmlApi, includeControllerXmlComments: true);

    var xmlApplication = Path.Combine(basePath, "Airline.Dtos.xml");
    if (File.Exists(xmlApplication))
    {
        c.IncludeXmlComments(xmlApplication);
    }
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    db.Seed();
}

app.MapDefaultEndpoints();

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

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
