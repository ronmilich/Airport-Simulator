using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProjectLibrary.Test
{
    public class ConfigurationTests
    {
        [Fact]
        public void GetStationsInitialState_ShouldReturnStationList()
        {
            int expected = 9;
            int actual = Configuration.GetStationsInitialState().Count;

            Assert.Equal(expected, actual);
        }
    }
}
