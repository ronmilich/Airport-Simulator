using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AirportSimulator.API.Models
{
    /// <summary>
    /// Flight class for model database.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// /Flight primary key
        /// </summary>
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// Flight state type: Landing / Departure
        /// </summary>
        [EnumDataType(typeof(StateType))]
        public StateType FlightStateType { get; set; }
        /// <summary>
        /// Station Id the this flight is in.
        /// </summary>
        public int StationId { get; set; }
    }

    [Serializable]
    public enum StateType
    {
        [EnumMember]
        Landing = 0,
        [EnumMember]
        Departure = 1
    }
}
