using System.Collections.Generic;

namespace ProjectLibrary
{
    /// <summary>
    /// Represent a station in the airport.
    /// </summary>
    public class Station : IStation
    {
        public int Id { get; set; }
        public bool IsOccupied { get; set; }
        public string CurrentFlightId { get; set; }
        public List<int> NextStations { get; set; }
        public bool IsDepartureLastStation { get; set; }
        public bool IsLandingLastStation { get; set; }
        public bool IsLandingFirstStation { get; set; }
        public bool IsDepartureFirstStation { get; set; }
    }
}
