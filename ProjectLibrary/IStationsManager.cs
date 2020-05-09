using System.Collections.Generic;

namespace ProjectLibrary
{
    /// <summary>
    /// Represent an interface of StationManager class.
    /// </summary>
    public interface IStationsManager
    {
        /// <summary>
        /// Search for a specific station in the Stations list propery and returns it.
        /// </summary>
        /// <param name="stationNumber">The number of the desired station</param>
        /// <returns>Single station from the stations list</returns>
        Station GetStation(int stationNumber);
        /// <summary>
        /// This method take the station passed by the flight object and pass it to the StationsManager class to update
        /// the station state.
        /// </summary>
        /// <param name="stationToUpdate">The station that the StationsManager class should update</param>
        Station UpdateStation(Station stationToUpdate);
        /// <summary>
        /// Get the first available landing or departure initial station.
        /// </summary>
        /// <param name="flightState">The state of the flight</param>
        /// <returns>Returns the first available station or null if no station is available</returns>
        Station GetAvailablInitialStation(StateType flightState);
        /// <summary>
        /// Get sum of flights from all the stations.
        /// </summary>
        /// <returns>Returns the sum of all flights</returns>
        int GetNumberOfFlightsInStations();
        /// <summary>
        /// Return all stations from the StationsManager.
        /// </summary>
        /// <returns>Return all stations from the StationsManager</returns>
        List<Station> GetStations();
        /// <summary>
        /// This method takes the initial state of the stations from the server.
        /// </summary>
        void SetInitialStations();
        /// <summary>
        /// Set the stations to their initial state.
        /// </summary>
        void ResetStations();
    }
}
