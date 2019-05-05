using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Routes.Application.Interfaces;
using Routes.Application.Validation;
using Routes.Core.Interfaces;
using Routes.Core.Entities;
using Routes.Core.RouteFinder;

namespace Routes.Application.Routes
{
    public class AppRoutes : IAppRoutes
    {
        private readonly IRepository _repository;

        public AppRoutes(IRepository repository)
        {
            _repository = repository;
        }

        public ConnectedRoute FindShortestRoute(string origin, string destination)
        {
            Validator.Validate(origin, destination);

            Airport originAirport = _repository.List<Airport>().FirstOrDefault(a => a.Iata == origin);
            Airport destinationAirport = _repository.List<Airport>().FirstOrDefault(a => a.Iata == destination);
            Validator.Validate(originAirport, destinationAirport);

            List<Route> routes = _repository.List<Route>(r => r.Airline, r => r.Origin, r => r.Destination);
            ShortestRouteFinder routeFinder = new ShortestRouteFinder(originAirport, destinationAirport, routes);
            ConnectedRoute shortestRoute = routeFinder.FindShortestRoute();

            return shortestRoute;
        }
    }
}
