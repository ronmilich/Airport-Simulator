using System;
using Xunit;

namespace ProjectLibrary.Test
{
    public class IStationsManagerTests
    {
        IStationsManager stationsManager = StationsManager.Instance;

        [Fact]
        public void GetStation_ReturnStationShouldWork()
        {
            int expected = 4;
            int actual = stationsManager.GetStation(expected).Id;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void GetStation_ReturnStationShouldFail(int stationNumber)
        {
            Assert.Null(stationsManager.GetStation(stationNumber));
        }


        [Fact]
        public void UpdateStation_ShouldReturnUpdatedStation()
        {
            Station station = new Station()
            {
                Id = 1,
                IsOccupied = true
            };

            bool expected = true;

            bool actual = stationsManager.UpdateStation(station).IsOccupied;

            Assert.True(expected == actual);
        }

        [Fact]
        public void GetAvailablInitialStation_ShouldReturnLandingStation()
        {
            int expected = 10;

            int actual = stationsManager.GetAvailablInitialStation(StateType.Landing).Id;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAvailablInitialStation_ShouldReturnDepartureStation()
        {
            int expected = 6;

            int actual = stationsManager.GetAvailablInitialStation(StateType.Departure).Id;

            Assert.Equal(expected, actual);
        }
    }
}
