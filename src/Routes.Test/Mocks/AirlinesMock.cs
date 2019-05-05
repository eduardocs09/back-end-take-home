using System.Collections.Generic;
using Routes.Core.Entities;

namespace Routes.Test.Mocks
{
    public class AirlinesMock
    {
        public static List<Airline> Airlines = new List<Airline>()
        {
            new Airline("Airline 1", "A1", "AL1", "Canada")
        };
    }
}
