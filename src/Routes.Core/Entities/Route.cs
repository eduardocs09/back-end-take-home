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

        public override bool Equals(object obj)
        {
            return obj is Route route &&
                Airline.Equals(route.Airline) &&
                Origin.Equals(route.Origin) &&
                Destination.Equals(route.Destination);
        }
    }
}
