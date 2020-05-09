using ProjectLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;

namespace ProjectLibrary
{
    /// <summary>
    /// Simulator class is responsible for generating flights
    /// </summary>
    public class Simulator : ISimulator
    {
        private static Simulator instance = null;
        public static Simulator Instance
        {
            get
            {
                if (instance == null)
                    instance = new Simulator();
                return instance;
            }
        }
        private StationsManager stationsManager = StationsManager.Instance;

        private Timer _flightsGeneratorTimer;

        public List<Flight> Flights { get; set; }

        /// <summary>
        /// Messages to pass to the UI.
        /// </summary>
        public string SimulationMessages { get; set; }

        private Simulator()
        {
            Flights = new List<Flight>();
            Configuration.MaxFlights = 5;
            SetInitialTimer();
        }

        /// <summary>
        /// This method is called every time the timer event is raised.
        /// </summary>
        private void GenerateFlight(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();

            if (Flights.Count < Configuration.MaxFlights)
            {
                StateType stateType = (StateType)random.Next(0, 2);
                string flightId = GenerateFlightId();
                var flight = new Flight(flightId, stateType);
                Flights.Add(flight);

                Console.WriteLine($"Flight {flight.Id} was generated | Current flights: {Flights.Count}\n");
                flight.InitialteFlight();
                return;
            }

            Console.WriteLine($"There can be just {Configuration.MaxFlights} in the airport at once.\n");
        }

        /// <summary>
        /// Sets the intial timer for the simulator
        /// </summary>
        private void SetInitialTimer()
        {
            _flightsGeneratorTimer = new Timer();
            _flightsGeneratorTimer.Elapsed += GenerateFlight;
        }

        /// <summary>
        /// This method generates random string of latters and numbers to create the flight id.
        /// </summary>
        /// <returns>Returns flight id that consist of 4 digits and 2 numbers</returns>
        private string GenerateFlightId()
        {
            Random random = new Random();
            string flightId = "";

            for (int i = 0; i < 4; i++)
            {
                char let = (char)random.Next('A', 'Z');
                flightId += let;
            }

            for (int i = 0; i < 2; i++)
            {
                int num = random.Next(0, 9);
                flightId += num;
            }

            return flightId;
        }

        public async void StartSimulator(int flightGenerationInterval)
        {
            FlightsProcessor api = new FlightsProcessor();
            await api.DeleteFlights();

            try
            {
                foreach (Flight flight in Flights)
                {
                    flight.InitialteFlight();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Unsubscribe Error " + e.Message);
            }

            _flightsGeneratorTimer.Interval = flightGenerationInterval;
            _flightsGeneratorTimer.Start();
        }

        public void StopSimulator()
        {
            SimulationMessages = "";
            _flightsGeneratorTimer.Stop();
            FlightsProcessor flightApi = new FlightsProcessor();

            var flightsList = new List<Flight>(Flights);
            flightApi.AddFlights(flightsList);

            foreach (var flight in Flights)
                flight.StopFlight();
        }

        public void LoadAssetsCurrentState()
        {
            FlightsProcessor api = new FlightsProcessor();

            List<Flight> flightsList = api.GetFlights().Result;
            Flights = flightsList;

            foreach (var flight in Flights)
                if (flight.CurrentStation != null)
                    stationsManager.UpdateStation(flight.CurrentStation);
        }

        public void RemoveFlight(Flight flight)
        {
            Flights.Remove(flight);
        }

        public async void Removeflights()
        {
            FlightsProcessor api = new FlightsProcessor();
            await api.DeleteFlights();
        }

        public async void ResetSimulationFlights()
        {
            _flightsGeneratorTimer.Stop();
            SimulationMessages = "";
            FlightsProcessor flightApi = new FlightsProcessor();
            await flightApi.DeleteFlights();

            foreach (var flight in Flights)
                flight.StopFlight();

            stationsManager.ResetStations();
        }
    }
}
