using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Routes.Application.Interfaces;
using Routes.Application.Validation;
using Routes.Core.Interfaces;
using Routes.Core.Entities;

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

            return null;
        }
    }
}
