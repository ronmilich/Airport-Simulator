using AirportSimulator.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace AirportSimulator.API.DbContexts
{
    /// <summary>
    /// Represent a connection to the database using Entity Framework.
    /// </summary>
    public class AirportDbContext : DbContext
    {
        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options) {  }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<int[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => int.Parse(val)).ToArray());

            modelBuilder.Entity<Station>()
                .Property(e => e.NextStations)
                .HasConversion(converter);

            modelBuilder.Entity<Station>().HasData(
                new Station()
                {
                    Id = 10,
                    IsOccupied = false,
                    NextStations = new int[] { 2 },
                    IsDepartureLastStation = false,
                    IsLandingLastStation = false,
                    IsLandingFirstStation = true,
                    IsDepartureFirstStation = false,
                    CurrentFlight = ""
                },
                new Station()
                {
                    Id = 1,
                    IsOccupied = false,
                    NextStations = new int[] { 2 },
                    IsDepartureLastStation = false,
                    IsLandingLastStation = false,
                    IsLandingFirstStation = true,
                    IsDepartureFirstStation = false,
                    CurrentFlight = ""
                },
                new Station()
                {
                    Id = 2,
                    IsOccupied = false,
                    NextStations = new int[] { 3 },
                    IsDepartureLastStation = true,
                    IsLandingLastStation = false,
                    IsLandingFirstStation = false,
                    IsDepartureFirstStation = false,
                    CurrentFlight = ""
                },
                new Station()
                {
                    Id = 3,
                    IsOccupied = false,
                    NextStations = new int[] { 4 },
                    IsDepartureLastStation = false,
                    IsLandingLastStation = false,
                    IsLandingFirstStation = false,
                    IsDepartureFirstStation = false,
                    CurrentFlight = ""
                },
                new Station()
                {
                    Id = 4,
                    IsOccupied = false,
                    NextStations = new int[] { 5 },
                    IsDepartureLastStation = true,
                    IsLandingLastStation = false,
                    IsLandingFirstStation = false,
                    IsDepartureFirstStation = false,
                    CurrentFlight = ""
                },
                new Station()
                {
                    Id = 5,
                    IsOccupied = false,
                    NextStations = new int[] { 6, 7 },
                    IsDepartureLastStation = false,
                    IsLandingLastStation = false,
                    IsLandingFirstStation = false,
                    IsDepartureFirstStation = false,
                    CurrentFlight = ""
                },
                new Station()
                {
                    Id = 6,
                    IsOccupied = false,
                    NextStations = new int[] { 8 },
                    IsDepartureLastStation = false,
                    IsLandingLastStation = true,
                    IsLandingFirstStation = false,
                    IsDepartureFirstStation = true,
                    CurrentFlight = ""
                },
                new Station()
                {
                    Id = 7,
                    IsOccupied = false,
                    NextStations = new int[] { 8 },
                    IsDepartureLastStation = false,
                    IsLandingLastStation = true,
                    IsLandingFirstStation = false,
                    IsDepartureFirstStation = true,
                    CurrentFlight = ""
                },
                new Station()
                {
                    Id = 8,
                    IsOccupied = false,
                    NextStations = new int[] { 4, 2 },
                    IsDepartureLastStation = false,
                    IsLandingLastStation = false,
                    IsLandingFirstStation = false,
                    IsDepartureFirstStation = false,
                    CurrentFlight = ""
                }
           );

            base.OnModelCreating(modelBuilder);
        }
    }
}
