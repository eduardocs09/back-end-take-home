using System.Collections.Generic;
using Routes.Core.Entities;

namespace Routes.Test.Mocks
{
    public class AirportsMock
    {
        public static List<Airport> Airports = new List<Airport>()
        {
            new Airport("Airport 1", "City 1", "Canada", "AP1", 0, 0),
            new Airport("Airport 2", "City 2", "Canada", "AP2", 0, 0),
            new Airport("Airport 3", "City 3", "Canada", "AP3", 0, 0),
            new Airport("Airport 4", "City 4", "Canada", "AP4", 0, 0),
            new Airport("Airport 5", "City 5", "Canada", "AP5", 0, 0),
            new Airport("Airport 6", "City 6", "Canada", "AP6", 0, 0),
            new Airport("Airport 7", "City 7", "Canada", "AP7", 0, 0),
            new Airport("Airport 8", "City 8", "Canada", "AP8", 0, 0),

            //Airports that are not connected to any of the above by any route
            new Airport("Airport 9", "City 9", "Canada", "AP9", 0, 0),
            new Airport("Airport 10", "City 10", "Canada", "A10", 0, 0),
            new Airport("Airport 11", "City 11", "Canada", "A11", 0, 0)
        };
    }
}
