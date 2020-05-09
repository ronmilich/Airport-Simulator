using System.Collections.Generic;

namespace ProjectLibrary
{
    /// <summary>
    /// Represent an interface of a station.
    /// </summary>
    public interface IStation
    {
        /// <summary>
        /// The number that the station can be recognized with.
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Tells if the station is occupied by a plane or empty.
        /// </summary>
        bool IsOccupied { get; set; }
        /// <summary>
        /// The flight in the current station. 
        /// </summary>
        string CurrentFlightId { get; set; }
        /// <summary>
        /// the next available stations that the flight can go to.
        /// </summary>
        List<int> NextStations { get; set; }
        /// <summary>
        /// Indicates if this station is a last station for departuring planes.
        /// </summary>
        bool IsDepartureLastStation { get; set; }
        /// <summary>
        /// Indicates if this station is a last station for landing planes.
        /// </summary>
        bool IsLandingLastStation { get; set; }
        /// <summary>
        /// Indicates if this is the first landing station.
        /// </summary>
        bool IsLandingFirstStation { get; set; }
        /// <summary>
        /// Indicates if this is the first departure station.
        /// </summary>
        bool IsDepartureFirstStation { get; set; }
    }
}
