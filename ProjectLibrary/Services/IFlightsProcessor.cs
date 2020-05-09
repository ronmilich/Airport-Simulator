using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectLibrary.Services
{
    /// <summary>
    /// Represent an interface of a flight api that sends data to the server and process data recieved from the server. all the function of the interface are asynchronous.
    /// </summary>
    public interface IFlightsProcessor
    {
        /// <summary>
        /// Gets a list of flights from the server.
        /// </summary>
        /// <returns>List of Flights.</returns>
        Task<List<Flight>> GetFlights();

        /// <summary>
        /// Get a single flight from the server using the flight id.
        /// </summary>
        /// <param name="flightId">Flight id.</param>
        /// <returns>Single flight.</returns>
        Task<Flight> GetFlight(string flightId);

        /// <summary>
        /// Add single flight to the server.
        /// </summary>
        /// <param name="flight">Flight to add.</param>
        void AddFlight(Flight flight);

        /// <summary>
        /// Add a list of flight to the server.
        /// </summary>
        /// <param name="flights">List of flights.</param>
        void AddFlights(List<Flight> flights);

        /// <summary>
        /// Delete single flights from the server.
        /// </summary>
        /// <param name="flight">Flight to delete</param>
        Task DeleteFlight(Flight flight);

        /// <summary>
        /// Delete all the flights from the server.
        /// </summary>
        Task DeleteFlights();

        /// <summary>
        /// Update single flight on the server.
        /// </summary>
        /// <param name="flight">Flight to update.</param>
        Task UpdateFlight(Flight flight);
    }
}