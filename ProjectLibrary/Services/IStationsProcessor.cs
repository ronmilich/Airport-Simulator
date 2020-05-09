using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectLibrary.Services
{
    /// <summary>
    /// Represent an interface of a station api that sends data to the server and process data recieved from the server. all the function of the interface are asynchronous.
    /// </summary>
    public interface IStationsProcessor
    {
        /// <summary>
        /// Load all the stations from the airport api.
        /// </summary>
        /// <returns>Returns the list of all stations at their current state.</returns>
        Task<List<Station>> LoadStations();

        /// <summary>
        /// Load a station with a specific id.
        /// </summary>
        /// <param name="stationId">The number of the station</param>
        /// <returns>Return station</returns>
        Task<Station> LoadStation(int stationId);

        /// <summary>
        /// Delete all stations from the airport database
        /// </summary>
        Task DeleteStations();

        /// <summary>
        /// This method should update the stations in the database.
        /// </summary>
        /// <param name="stationsToUpdate">The list of stations with the current state</param>
        Task UpdateStations(List<Station> stationsToUpdate);
    }
}