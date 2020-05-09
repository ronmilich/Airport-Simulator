using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ProjectLibrary
{
    /// <summary>
    /// Contains all the configurations needed for the project library
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// The path to the file with all the stations and their initial state.
        /// </summary>
        static readonly string path = "stations.json";
        
        /// <summary>
        /// The initial state of the station taken from the stations.json file.
        /// </summary>
        static readonly List<Station> stationsInitialState;
        
        /// <summary>
        /// Maximum flights that can be in the airport at once.
        /// </summary>
        public static int MaxFlights { get; set; }

        /// <summary>
        /// A static property that represent the time that should be passed before a flight instance can make a request or wait at the station. The time is in milliseconds.
        /// </summary>
        public static int FlightsMovementSpeed { get; set; }

        static Configuration()
        {
            FlightsMovementSpeed = 1000;
            stationsInitialState = JsonConvert.DeserializeObject<List<Station>>(File.ReadAllText(path));
        }

        /// <summary>
        /// Get all the stations at their initial state.
        /// </summary>
        /// <returns>List of stations with their initial state.</returns>
        public static List<Station> GetStationsInitialState()
        {
            return JsonConvert.DeserializeObject<List<Station>>(File.ReadAllText(path));
        }
    }

}
