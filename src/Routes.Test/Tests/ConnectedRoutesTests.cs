using System;
using System.Collections.Generic;
using Routes.Test.Base;
using Routes.Test.Mocks;
using Xunit;

namespace Routes.Test.Tests
{
    public class ConnectedRoutesTests : BaseTest
    {
        [Fact]
        public void AddRouteTest()
        {
            var connecteRoute = ConnectedRoutesMock.MultipleRouteConnectedRoutes[0];
            connecteRoute.AddRoute(RoutesMock.Routes[6]);
            Assert.Equal(connecteRoute.Destination, RoutesMock.Routes[6].Destination);
        }
    }
}
