namespace ProjectLibrary.Services
{
    /// <summary>
    /// This class is represent a data transer object that the client pass to the server.
    /// </summary>
    class FlightDto
    {
        public string Id { get; set; }
        public StateType FlightStateType { get; set; }
        public int StationId { get; set; }

        public FlightDto(string id, StateType flightStateType, int stationId)
        {
            Id = id;
            FlightStateType = flightStateType;
            StationId = stationId;
        }
    }
}
