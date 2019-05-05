using System;
using System.Collections.Generic;
using System.Text;
using Routes.Application.Interfaces;
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
            return null;
        }
    }
}
