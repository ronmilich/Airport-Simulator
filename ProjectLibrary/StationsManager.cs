using ProjectLibrary.Services;
using System.Collections.Generic;

namespace ProjectLibrary
{
    /// <summary>
    /// Represent a class that aggregates all the stations and manage them.
    /// </summary>
    public class StationsManager : IStationsManager
    {
        private static StationsManager instance = null;
        private List<Station> _stations = new List<Station>();

        private StationsManager()
        {
            _stations = Configuration.GetStationsInitialState();
        }

        public static StationsManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new StationsManager();
                return instance;
            }
        }

        public Station GetStation(int stationNumber)
        {
            var station = _stations.Find(s => s.Id == stationNumber);

            if (station == null)
                return null;

            return station;
        }

        public Station GetAvailablInitialStation(StateType flightState)
        {
            if (flightState == StateType.Landing)
            {
                foreach (Station station in _stations)
                {
                    if (station.IsLandingFirstStation == true && station.IsOccupied == false)
                        return station;
                }
            }
            else
            {
                foreach (Station station in _stations)
                {
                    if (station.IsDepartureFirstStation == true && station.IsOccupied == false)
                        return station;
                }
            }

            return null;
        }

        public Station UpdateStation(Station stationToUpdate)
        {
            int index = _stations.FindIndex(s => s.Id == stationToUpdate.Id);
            _stations[index] = stationToUpdate;
            return _stations[index];
        }

        public int GetNumberOfFlightsInStations()
        {
            int counter = 0;
            foreach (Station station in _stations)
            {
                if (!string.IsNullOrEmpty(station.CurrentFlightId))
                    counter++;
            }

            return counter;
        }

        public List<Station> GetStations()
        {
            return _stations;
        }

        public void SetInitialStations()
        {
            StationsProcessor api = new StationsProcessor();
            _stations = api.LoadStations().Result;
        }

        public void ResetStations()
        {
            _stations = Configuration.GetStationsInitialState();
        }
    }
}
