using System;

namespace ProjectLibrary
{
    /// <summary>
    /// This is a singleton class that works as a mediator between the Flight and the StationsManager classes.
    /// The dispatcher passes the information from the flight to stations manager and vice versa.
    /// </summary>
    public class Dispatcher : IDispatcher
    {
        private static Dispatcher instance = null;
        private static readonly object _syncRoot = new object();

        public static Dispatcher Instance
        {
            get
            {
                if (instance == null)
                    instance = new Dispatcher();
                return instance;
            }
        }

        public Station GetNextStation(Flight flight)
        {
            lock (_syncRoot)
            {
                var stationsManager = StationsManager.Instance;
                if (flight.CurrentStation == null)
                {
                    var initialStatoin = stationsManager.GetAvailablInitialStation(flight.FlightStateType);
                    if (initialStatoin != null)
                    {
                        Console.WriteLine($"Dispatcher returned initial station number {initialStatoin.Id} for flight {flight.Id}\n");
                        return initialStatoin;
                    }

                    Console.WriteLine($"All the initial stations are occupied, Try again later...\n");
                    return null;
                }


                foreach (var stationNumber in flight.CurrentStation.NextStations)
                {
                    Station station = stationsManager.GetStation(stationNumber);
                    if (station == null)
                    {
                        Console.WriteLine("All the preceding stations are occupied, try again later...\n");
                        return null;
                    }

                    if (station.IsOccupied == false)
                    {
                        Console.WriteLine($"Dispatcher returned station number {station.Id} for flight {flight.Id}\n");
                        return station;
                    }
                }

                Console.WriteLine("There is no available stations at the moment, please try again later...\n");
                return null;
            }
        }
    }
}
