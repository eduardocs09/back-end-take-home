using System;
using Routes.Core.Base;

namespace Routes.Core.Entities
{
    public class Airport : Entity
    {
        public string Name { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Iata { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Airport()
        { }

        public Airport(string name, string city, string country, string iata, double latitude, double longitude)
        {
            Id = Guid.NewGuid();
            Name = name;
            City = city;
            Country = country;
            Iata = iata;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
