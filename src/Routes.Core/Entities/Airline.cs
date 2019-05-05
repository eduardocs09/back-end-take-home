using Routes.Core.Base;
using System;

namespace Routes.Core.Entities
{
    public class Airline : Entity
    {
        public string Name { get; private set; }
        public string TwoDigitCode { get; private set; }
        public string ThreeDigitCode { get; private set; }
        public string Country { get; private set; }

        public Airline()
        { }

        public Airline(string name, string twoDigitCode, string threeDigitCode, string country)
        {
            Id = Guid.NewGuid();
            Name = name;
            TwoDigitCode = twoDigitCode;
            ThreeDigitCode = threeDigitCode;
            Country = country;
        }
    }
}
