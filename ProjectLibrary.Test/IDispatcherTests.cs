using System.Collections.Generic;
using Xunit;

namespace ProjectLibrary.Test
{
    public class IDispatcherTests
    {
        IDispatcher dispatcher = Dispatcher.Instance;

        [Fact]
        public void GetNextStation_ShouldReturnStation()
        {
            Station currentStatoin = new Station() { NextStations = new List<int>() { 3 } };

            Flight flight = new Flight("a", StateType.Departure) { CurrentStation = currentStatoin };

            int expected = 3;

            Station actual = dispatcher.GetNextStation(flight);

            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Id);
        }

        [Fact]
        public void GetNextStation_ShouldReturnNull()
        {
            Station currentStatoin = new Station() { NextStations = new List<int>() { 12 } };

            Flight flight = new Flight("a", StateType.Departure) { CurrentStation = currentStatoin };

            Station station = dispatcher.GetNextStation(flight);

            Assert.Null(station);
        }

    }
}
