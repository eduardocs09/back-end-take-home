using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Routes.Application.Routes;
using Routes.Core.Entities;
using Routes.Core.Interfaces;
using Routes.Test.Base;
using Routes.Test.Mocks;
using Xunit;

namespace Routes.Test.Tests
{
     public class InvalidParametersTests : BaseTest
    {
        public InvalidParametersTests()
        {
            _repository.Setup(r => r.List<Airport>()).Returns(AirportsMock.Airports);
        }

        [Fact]
        public void EmptyParametersTest()
        {
            var appRoutes = new AppRoutes(_repository.Object);
            Assert.Throws<ArgumentNullException>(() => appRoutes.FindShortestRoute(string.Empty, string.Empty));
        }

        [Fact]
        public void EmptyOriginTest()
        {
            var appRoutes = new AppRoutes(_repository.Object);
            Assert.Throws<ArgumentNullException>(() => appRoutes.FindShortestRoute(string.Empty, AirportsMock.Airports[0].Iata));
        }

        [Fact]
        public void EmptyDestinationTest()
        {
            var appRoutes = new AppRoutes(_repository.Object);
            Assert.Throws<ArgumentNullException>(() => appRoutes.FindShortestRoute(AirportsMock.Airports[0].Iata, string.Empty));
        }

        [Fact]
        public void InexistentAirportsTest()
        {
            var appRoutes = new AppRoutes(_repository.Object);
            Assert.Throws<KeyNotFoundException>(() => appRoutes.FindShortestRoute("123", "123"));
        }

        [Fact]
        public void InexistentOriginTest()
        {
            var appRoutes = new AppRoutes(_repository.Object);
            Assert.Throws<KeyNotFoundException>(() => appRoutes.FindShortestRoute("123", AirportsMock.Airports[0].Iata));
        }

        [Fact]
        public void InexistentDestinationTest()
        {
            var appRoutes = new AppRoutes(_repository.Object);
            Assert.Throws<KeyNotFoundException>(() => appRoutes.FindShortestRoute(AirportsMock.Airports[0].Iata, "123"));
        }
    }
}
