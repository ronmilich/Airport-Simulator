using AirportSimulator.API.Models;
using System.Collections.Generic;

namespace AirportSimulator.API.Services
{
    /// <summary>
    /// Repository Service interface that expose all repository service methods. This service interface injected in the startup class to be used thoughout the application.
    /// </summary>
    public interface IAirportRepository
    {
        /// <summary>
        /// Get single station using station id.
        /// </summary>
        /// <param name="stationId">Statin id.</param>
        /// <returns>Single station.</returns>
        Station GetStation(int stationId);
        /// <summary>
        /// Get all stations.
        /// </summary>
        /// <returns>List of Stations.</returns>
        List<Station> GetStations();
        /// <summary>
        /// Deletes all the stations from the database.
        /// </summary>
        void DeleteAllStations();
        /// <summary>
        /// Get single flight using fligh id.
        /// </summary>
        /// <param name="flightId">Fligh id</param>
        /// <returns>Single Flight</returns>
        Flight GetFlight(string flightId);
        /// <summary>
        /// Get all flights from the database.
        /// </summary>
        /// <returns>List of Flights.</returns>
        List<Flight> GetFlights();
        /// <summary>
        /// Delete a single flight from database.
        /// </summary>
        /// <param name="flight">Flight to delete.</param>
        void DeleteFlight(Flight flight);
        /// <summary>
        /// Delete all flights from the database.
        /// </summary>
        void DeleteAllFlights();
        /// <summary>
        /// Add flight to the database.
        /// </summary>
        /// <param name="flight">Flight to add from the client.</param>
        void AddFlight(Flight flight);
        /// <summary>
        /// Add list of flights to the database.
        /// </summary>
        /// <param name="flights">List of flights passed from the client</param>
        void AddFlights(List<Flight> flights);
        /// <summary>
        /// Saves all the changes to the database.
        /// </summary>
        void Save();
    }
}
