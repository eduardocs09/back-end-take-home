using System;
using Routes.Core.Base;

namespace Routes.Core.Entities
{
    public class Route : Entity
    {
        public Airline Airline { get; private set; }
        public Airport Origin { get; private set; }
        public Airport Destination { get; private set; }

        public Route()
        { }

        public Route(Airline airline, Airport origin, Airport destination)
        {
            Id = Guid.NewGuid();
            Airline = airline;
            Origin = origin;
            Destination = destination;
        }
    }
}
