using System.ComponentModel.DataAnnotations;

namespace AirportSimulator.API.Models
{
    /// <summary>
    /// Station class model for database.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// The number that the station can be recognized with.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Tells if the station is occupied by a plane or empty.
        /// </summary>
        public bool IsOccupied { get; set; }
        /// <summary>
        /// the next available stations that the flight can go to
        /// </summary>
        public int[] NextStations { get; set; }
        /// <summary>
        /// Indicates if this station is a last station for departuring planes
        /// </summary>
        public bool IsDepartureLastStation { get; set; }
        /// <summary>
        /// Indicates if this station is a last station for landing planes
        /// </summary>
        public bool IsLandingLastStation { get; set; }
        /// <summary>
        /// Indicates if this is the first landing station
        /// </summary>
        public bool IsLandingFirstStation { get; set; }
        /// <summary>
        /// Indicates if this is the first departure station
        /// </summary>
        public bool IsDepartureFirstStation { get; set; }
        /// <summary>
        /// The flight in the current station. 
        /// </summary>
        public string CurrentFlight { get; set; }
    }
}
