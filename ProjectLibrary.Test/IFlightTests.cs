using Xunit;

namespace ProjectLibrary.Test
{
    public class IFlightTests
    {
        Flight flight = new Flight("AAAA66", StateType.Departure);

        [Theory]
        [InlineData(null, StateType.Departure)]
        [InlineData(null, StateType.Landing)]
        public void CheckForLastStation_ShouldReturnFalseWhenStationIsNull(Station currentstation, StateType flightStateType)
        {
            Assert.False(flight.CheckForLastStation(currentstation, flightStateType));
        }

        [Fact]
        public void CheckForLastStation_ShouldReturnTrue()
        {
            Station currentStation = new Station()
            {
                IsDepartureLastStation = true
            };

            Assert.True(flight.CheckForLastStation(currentStation, StateType.Departure));
        }

        [Fact]
        public void GenerateFlightId_ShouldReturnSixDigitsString()
        {
            int expected = 6;

            int actual = flight.Id.Length;

            Assert.Equal(expected, actual);
        }
    }
}
