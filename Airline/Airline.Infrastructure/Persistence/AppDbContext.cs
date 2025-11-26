using Airline.Domain.DataSeeder;
using Airline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<AircraftFamily> AircraftFamilys { get; set; }

    public DbSet<AircraftModel> AircraftModels { get; set; }

    public DbSet<Flight> Flights { get; set; }

    public DbSet<Passenger> Passengers { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var dataFixture = new DataFixture();

        modelBuilder.Entity<AircraftFamily>(fam =>
        {
            fam.HasKey(air => air.Id);

            fam.Property(air => air.ModelName)
                .IsRequired()
                .HasMaxLength(128);

            fam.Property(air => air.ManufacturerName)
                .IsRequired()
                .HasMaxLength(128);
        });

        modelBuilder.Entity<AircraftModel>(mode =>
        {
            mode.HasKey(am => am.Id);

            mode.Property(am => am.Name)
                 .IsRequired()
                 .HasMaxLength(128);

            mode.Property(am => am.FlightRange)
                 .IsRequired()
                 .HasMaxLength(5);

            mode.Property(am => am.PassengerCapacity)
                 .IsRequired()
                 .HasMaxLength(3);

            mode.Property(am => am.CargoCapacity)
                 .IsRequired()
                 .HasMaxLength(2);

            mode.HasOne(am => am.ModelFamily)
                 .WithMany()
                 .HasForeignKey("ModelFamilyId")
                 .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Flight>(f =>
        {
            f.HasKey(f => f.Id);

            f.Property(f => f.Code)
              .IsRequired()
              .HasMaxLength(20);

            f.Property(f => f.DeparturePoint)
              .IsRequired()
              .HasMaxLength(200);

            f.Property(f => f.ArrivalPoint)
              .IsRequired()
              .HasMaxLength(200);

            f.Property(f => f.DepartureDateTime)
              .IsRequired();

            f.Property(f => f.ArrivalDateTime)
              .IsRequired();

            f.HasOne(f => f.AircraftModel)
              .WithMany()
              .HasForeignKey("AircraftModelId")
              .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Passenger>(pass =>
        {
            pass.HasKey(pass => pass.Id);

            pass.Property(pass => pass.PassportNumber)
                 .IsRequired()
                 .HasMaxLength(11);

            pass.Property(pass => pass.FullName)
                 .IsRequired()
                 .HasMaxLength(100);

            pass.Property(pass => pass.BirthDate)
                 .IsRequired();

        });

        modelBuilder.Entity<Ticket>(tick =>
        {
            tick.HasKey(tick => tick.Id);

            tick.Property(tick => tick.SeatNumber)
                 .IsRequired()
                 .HasMaxLength(10);

            tick.Property(tick => tick.IsHandLuggage)
                 .IsRequired();

            tick.Property(tick => tick.TotalBaggageWeight)
                 .IsRequired(false);

            tick.HasOne(tick => tick.Flight)
                 .WithMany()
                 .HasForeignKey("FlightId")
                 .OnDelete(DeleteBehavior.Restrict);

            tick.HasOne(tick => tick.Passenger)
                 .WithMany()
                 .HasForeignKey("PassengerId")
                 .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
