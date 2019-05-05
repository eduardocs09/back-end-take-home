using System;
using System.Collections.Generic;
using System.Text;
using Routes.Core.Entities;

namespace Routes.Test.Mocks
{
    public class RoutesMock
    {
        public static List<Route> Routes = new List<Route>()
        {
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[0], AirportsMock.Airports[1]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[0], AirportsMock.Airports[2]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[1], AirportsMock.Airports[3]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[1], AirportsMock.Airports[4]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[2], AirportsMock.Airports[5]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[2], AirportsMock.Airports[6]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[3], AirportsMock.Airports[7]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[4], AirportsMock.Airports[6]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[1], AirportsMock.Airports[0]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[2], AirportsMock.Airports[0]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[3], AirportsMock.Airports[1]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[4], AirportsMock.Airports[1]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[5], AirportsMock.Airports[2]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[6], AirportsMock.Airports[2]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[7], AirportsMock.Airports[3]),
            
            //Routes that are not connected to ones above
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[8], AirportsMock.Airports[9]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[8], AirportsMock.Airports[10]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[9], AirportsMock.Airports[8]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[9], AirportsMock.Airports[10]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[10], AirportsMock.Airports[8]),
            new Route(AirlinesMock.Airlines[0], AirportsMock.Airports[10], AirportsMock.Airports[9])
        };
    }
}
