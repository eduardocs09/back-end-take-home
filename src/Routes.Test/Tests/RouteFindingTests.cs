using System;
using System.Collections.Generic;
using Routes.Application.Routes;
using Routes.Core.Entities;
using Routes.Test.Base;
using Routes.Test.Mocks;
using Xunit;

namespace Routes.Test.Tests
{
    public class RouteFindingTests : BaseTest
    {
        private AppRoutes _appRoutes;
        public RouteFindingTests()
        {
            _repository.Setup(r => r.List<Airport>()).Returns(AirportsMock.Airports);
            _repository.Setup(r => r.List<Route>()).Returns(RoutesMock.Routes);
            _appRoutes = new AppRoutes(_repository.Object);
        }

        [Fact]
        public void InexistentRouteTest()
        {
            var origin = AirportsMock.Airports[0].Iata;
            var destination = AirportsMock.Airports[8].Iata;
            ConnectedRoute route = _appRoutes.FindShortestRoute(origin, destination);
            Assert.Empty(route.Routes);
        }

        [Fact]
        public void SingleDirectRouteTest()
        {
            var origin = AirportsMock.Airports[0].Iata;
            var destination = AirportsMock.Airports[1].Iata;
            ConnectedRoute route = _appRoutes.FindShortestRoute(origin, destination);
            Assert.Equal(route.Routes, ConnectedRoutesMock.SingleRouteConnectedRoutes[0].Routes);
        }

        [Fact]
        public void SingleConnectedRouteTest()
        {
            var origin = AirportsMock.Airports[0].Iata;
            var destination = AirportsMock.Airports[7].Iata;
            ConnectedRoute route = _appRoutes.FindShortestRoute(origin, destination);
            Assert.Equal(route.Routes, ConnectedRoutesMock.MultipleRouteConnectedRoutes[1].Routes);
        }

        [Fact]
        public void ShortestConnectedRouteTest()
        {
            var origin = AirportsMock.Airports[0].Iata;
            var destination = AirportsMock.Airports[6].Iata;
            ConnectedRoute route = _appRoutes.FindShortestRoute(origin, destination);
            Assert.Equal(route.Routes, ConnectedRoutesMock.MultipleRouteConnectedRoutes[2].Routes);
        }
    }
}