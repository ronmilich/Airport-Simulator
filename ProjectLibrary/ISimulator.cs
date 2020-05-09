namespace ProjectLibrary
{
    /// <summary>
    /// Represents the interface of the Simulator class
    /// </summary>
    interface ISimulator
    {
        /// <summary>
        /// This method starts the timer of the simulator.
        /// </summary>
        /// <param name="flightGenerationInterval">Represents the interval between the calls to the simulator time in millisecondes.</param>
        void StartSimulator(int flightGenerationInterval);
        /// <summary>
        /// Stops the timer of the simulator.
        /// </summary>
        void StopSimulator();
        /// <summary>
        /// This method load all the stations and flights at their current state. if the loading of the simulator never has been loaded,
        /// the simulation will load the initial state of the stations with no flights.
        /// </summary>
        void LoadAssetsCurrentState();
        /// <summary>
        /// Removes a specific flight from the list of lights in the simulator.
        /// </summary>
        void RemoveFlight(Flight flight);
        /// <summary>
        /// Remove existing flights from the simulation and database
        /// </summary>
        void Removeflights();
        /// <summary>
        /// Delete all the flights from the database and stops simulation - should be used when the flights are in deadlock
        /// </summary>
        void ResetSimulationFlights();
    }
}
