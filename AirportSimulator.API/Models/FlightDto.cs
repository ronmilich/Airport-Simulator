namespace AirportSimulator.API.Models
{
    /// <summary>
    /// Data transfer object that is consumed the logic library.
    /// </summary>
    public class FlightDto
    {
        public string Id { get; set; }
        public StateType FlightStateType { get; set; }
        public Station CurrentStation { get; set; }
    }
}
