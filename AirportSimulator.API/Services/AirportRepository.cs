using AirportSimulator.API.DbContexts;
using AirportSimulator.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace AirportSimulator.API.Services
{
    /// <summary>
    /// This repository service class implements method for working with the database using Entity Framework.
    /// </summary>
    public class AirportRepository : IAirportRepository
    {
        private readonly AirportDbContext _context;

        public AirportRepository(AirportDbContext context)
        {
            _context = context;
        }

        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
        }

        public void DeleteAllStations()
        {
            var stations = _context.Stations.ToList();
            _context.Stations.RemoveRange(stations);
        }

        public void DeleteFlight(Flight flight)
        {
            _context.Flights.Remove(flight);
        }

        public Flight GetFlight(string flightId)
        {
            return _context.Flights.FirstOrDefault(flight => flight.Id == flightId);
        }

        public List<Flight> GetFlights()
        {
            return _context.Flights.ToList();
        }

        public Station GetStation(int stationId)
        {
            var station = _context.Stations.FirstOrDefault(station => station.Id == stationId);
            return station;
        }

        public List<Station> GetStations()
        {
            return _context.Stations.ToList();
        }

        public void AddFlights(List<Flight> flights)
        {
            foreach (var flight in flights)
                _context.Flights.Add(flight);
        }

        public void DeleteAllFlights()
        {
            var flights = _context.Flights.ToList();
            _context.Flights.RemoveRange(flights);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
