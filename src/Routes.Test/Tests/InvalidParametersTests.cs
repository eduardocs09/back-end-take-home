using System;
using System.Collections.Generic;
using Routes.Application.Routes;
using Routes.Core.Entities;
using Routes.Test.Base;
using Routes.Test.Mocks;
using Xunit;

namespace Routes.Test.Tests
{
     public class InvalidParametersTests : BaseTest
    {
        private AppRoutes _appRoutes;
        public InvalidParametersTests()
        {
            _repository.Setup(r => r.List<Airport>()).Returns(AirportsMock.Airports);
            _appRoutes = new AppRoutes(_repository.Object);
        }

        [Fact]
        public void EmptyParametersTest()
        {
            Assert.Throws<ArgumentNullException>(() => _appRoutes.FindShortestRoute(string.Empty, string.Empty));
        }

        [Fact]
        public void EmptyOriginTest()
        {
            Assert.Throws<ArgumentNullException>(() => _appRoutes.FindShortestRoute(string.Empty, AirportsMock.Airports[0].Iata));
        }

        [Fact]
        public void EmptyDestinationTest()
        {
            Assert.Throws<ArgumentNullException>(() => _appRoutes.FindShortestRoute(AirportsMock.Airports[0].Iata, string.Empty));
        }

        [Fact]
        public void InexistentAirportsTest()
        {
            Assert.Throws<KeyNotFoundException>(() => _appRoutes.FindShortestRoute("123", "123"));
        }

        [Fact]
        public void InexistentOriginTest()
        {
            Assert.Throws<KeyNotFoundException>(() => _appRoutes.FindShortestRoute("123", AirportsMock.Airports[0].Iata));
        }

        [Fact]
        public void InexistentDestinationTest()
        {
            Assert.Throws<KeyNotFoundException>(() => _appRoutes.FindShortestRoute(AirportsMock.Airports[0].Iata, "123"));
        }
    }
}
