using Airline.Domain.DataSeeder;
using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Persistence;

/// <summary>
/// Represents the application's database context.
/// Provides DbSet properties for all domain entities and configures entity mappings.
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the AircraftFamily entities.
    /// </summary>
    public DbSet<AircraftFamily> AircraftFamilys { get; set; }

    /// <summary>
    /// Gets or sets the AircraftModel entities.
    /// </summary>
    public DbSet<AircraftModel> AircraftModels { get; set; }

    /// <summary>
    /// Gets or sets the Flight entities.
    /// </summary>
    public DbSet<Flight> Flights { get; set; }

    /// <summary>
    /// Gets or sets the Passenger entities.
    /// </summary>
    public DbSet<Passenger> Passengers { get; set; }

    /// <summary>
    /// Gets or sets the Ticket entities.
    /// </summary>
    public DbSet<Ticket> Tickets { get; set; }

    /// <summary>
    /// Configures the entity mappings for all domain entities.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var dataFixture = new DataSeeder();

        modelBuilder.Entity<AircraftFamily>(fam =>
        {
            fam.HasKey(air => air.Id);

            fam.Property(air => air.Id)
                .HasColumnName("id");

            fam.Property(air => air.ModelName)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("name");

            fam.Property(air => air.ManufacturerName)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<AircraftModel>(mode =>
        {
            mode.HasKey(am => am.Id);

            mode.Property(am => am.Id)
                 .HasColumnName("id");

            mode.Property(am => am.Name)
                 .IsRequired()
                 .HasMaxLength(128)
                 .HasColumnName("name");

            mode.Property(am => am.FlightRange)
                 .IsRequired()
                 .HasMaxLength(5)
                 .HasColumnName("flight_range");


            mode.Property(am => am.PassengerCapacity)
                 .IsRequired()
                 .HasMaxLength(3)
                 .HasColumnName("passenger_capacity");

            mode.Property(am => am.CargoCapacity)
                 .IsRequired()
                 .HasMaxLength(2)
                 .HasColumnName("cargo_capacity");

            mode.HasOne(am => am.ModelFamily)
                 .WithMany()
                 .HasForeignKey("ModelFamilyId")
                 .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Flight>(f =>
        {
            f.HasKey(f => f.Id);

            f.Property(f => f.Id)
              .HasColumnName("id");

            f.Property(f => f.Code)
              .IsRequired()
              .HasMaxLength(20)
              .HasColumnName("code");

            f.Property(f => f.DeparturePoint)
              .IsRequired()
              .HasMaxLength(200)
              .HasColumnName("departure_point");

            f.Property(f => f.ArrivalPoint)
              .IsRequired()
              .HasMaxLength(200)
              .HasColumnName("arrival_point");

            f.Property(f => f.DepartureDateTime)
              .IsRequired()
              .HasColumnName("departure_datetime");

            f.Property(f => f.ArrivalDateTime)
              .IsRequired()
              .HasColumnName("arrival_datetime");

            f.HasOne(f => f.AircraftModel)
              .WithMany()
              .HasForeignKey("AircraftModelId")
              .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Passenger>(pass =>
        {
            pass.HasKey(pass => pass.Id);

            pass.Property(pass => pass.Id)
                 .HasColumnName("id");

            pass.Property(pass => pass.PassportNumber)
                 .IsRequired()
                 .HasMaxLength(11)
                 .HasColumnName("passport_number");

            pass.Property(pass => pass.FullName)
                 .IsRequired()
                 .HasMaxLength(100)
                 .HasColumnName("full_name");

            pass.Property(pass => pass.BirthDate)
                 .IsRequired()
                 .HasColumnName("birth_date");

        });

        modelBuilder.Entity<Ticket>(tick =>
        {
            tick.HasKey(tick => tick.Id);

            tick.Property(tick => tick.Id)
                 .HasColumnName("id");

            tick.Property(tick => tick.SeatNumber)
                 .IsRequired()
                 .HasMaxLength(10)
                 .HasColumnName("seat_number");

            tick.Property(tick => tick.IsHandLuggage)
                 .IsRequired()
                 .HasColumnName("is_hand_luggage");

            tick.Property(tick => tick.TotalBaggageWeight)
                 .IsRequired(false)
                 .HasColumnName("total_baggage_weight");

            tick.HasOne(tick => tick.Flight)
                 .WithMany()
                 .HasForeignKey("FlightId")
                 .OnDelete(DeleteBehavior.Cascade);

            tick.HasOne(tick => tick.Passenger)
                 .WithMany()
                 .HasForeignKey("PassengerId")
                 .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
