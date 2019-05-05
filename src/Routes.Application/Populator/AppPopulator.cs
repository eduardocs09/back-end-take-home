using System;
using System.Collections.Generic;
using System.Linq;
using Routes.Application.Interfaces;
using Routes.Core.Entities;
using Routes.Core.Interfaces;
using Routes.Infrastructure.Interfaces;

namespace Routes.Application.Populator
{
    public class AppPopulator : IAppPopulator
    {
        private const string AIRLINES_FILE_PATH = "../../data/airlines.csv";
        private const string AIRPORTS_FILE_PATH = "../../data/airports.csv";
        private const string ROUTES_FILE_PATH = "../../data/routes.csv";

        private readonly IFileReader _fileReader;
        private readonly IRepository _repository;

        public AppPopulator(IFileReader fileReader, IRepository repository)
        {
            _fileReader = fileReader;
            _repository = repository;
        }

        public int PopulateDatabase()
        {
            List<string> linesAirlines = _fileReader.ReadFileLines(AIRLINES_FILE_PATH).ToList();
            List<string> linesAirports = _fileReader.ReadFileLines(AIRPORTS_FILE_PATH).ToList();
            List<string> linesRoutes = _fileReader.ReadFileLines(ROUTES_FILE_PATH).ToList();
            
            List<Airline> airlines = ExtractAirlinesFromLines(linesAirlines);
            List<Airport> airports = ExtractAirportsFromLines(linesAirports);
            List<Route> routes = ExtractRoutesFromLines(linesRoutes, airlines, airports);


            _repository.RemoveAll<Airline>();
            _repository.RemoveAll<Airport>();
            _repository.RemoveAll<Route>();

            int recordsAdded = 0;
            recordsAdded += _repository.AddRange(airlines.ToArray());
            recordsAdded += _repository.AddRange(airports.ToArray());
            recordsAdded += _repository.AddRange(routes.ToArray());
            
            return recordsAdded;
        }

        private List<Airline> ExtractAirlinesFromLines(List<string> lines)
        {
            var airlines = new List<Airline>();
            foreach (var line in lines)
            {
                string[] splittedString = line.Split(",");
                var airline = new Airline(
                    splittedString[0],
                    splittedString[1],
                    splittedString[2],
                    splittedString[3]);

                airlines.Add(airline);
            }
            return airlines;
        }

        private List<Airport> ExtractAirportsFromLines(List<string> lines)
        {
            var airports = new List<Airport>();
            foreach (var line in lines)
            {
                string[] splittedString = line.Split(",");
                double.TryParse(splittedString[4], out double latitude);
                double.TryParse(splittedString[5], out double longitude);
                var airport = new Airport(
                    splittedString[0],
                    splittedString[1],
                    splittedString[2],
                    splittedString[3],
                    latitude,
                    longitude);

                if (airport.Iata != "\\N")
                    airports.Add(airport);
            }
            return airports;
        }

        private List<Route> ExtractRoutesFromLines(List<string> lines, List<Airline> airlines, List<Airport> airports)
        {
            var routes = new List<Route>();
            foreach (var line in lines)
            {
                string[] splittedString = line.Split(",");

                string airlineCode = splittedString[0];
                string originCode = splittedString[1];
                string destinationCode = splittedString[2];

                Airline airline = airlines.FirstOrDefault(a => a.TwoDigitCode == airlineCode);
                Airport origin = airports.FirstOrDefault(a => a.Iata == originCode);
                Airport destination = airports.FirstOrDefault(a => a.Iata == destinationCode);

                if ((airline != null) && (origin != null) && (destination != null))
                {
                    Route route = new Route(airline, origin, destination);
                    routes.Add(route);
                }
            }
            return routes;
        }
    }
}
