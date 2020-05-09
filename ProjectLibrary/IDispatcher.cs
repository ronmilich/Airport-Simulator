namespace ProjectLibrary
{
    /// <summary>
    /// Represent an interface of a flights dipatcher. It is the mediator between the Flight and the StationsManager classes, e.g.,
    /// pass the information between those classes
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Request the next station available for the current flight depending on the state of the flight. 
        /// </summary>
        /// <param name="flightState">The state of the flight that the Dispatcher passes to the StationsManager
        /// to determine which station should be returned.</param>
        /// <param name="curerntStation">The current station that the flight is on.</param>
        /// <returns>Should return the next available station</returns>
        Station GetNextStation(Flight flight);
    }
}
