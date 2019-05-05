using System;
using System.Collections.Generic;
using System.Linq;
using Routes.Core.Entities;

namespace Routes.Core.RouteFinder
{
    public class ShortestRouteFinder
    {
        private Airport _origin;
        private Airport _destination;
        private List<Route> _routes;

        private List<ConnectedRoute> _connectedRoutes;
        private HashSet<string> _connectedAirportCodes;

        public ShortestRouteFinder()
        {}

        public ShortestRouteFinder(Airport origin, Airport destination, IEnumerable<Route> availableRoutes)
        {
            _origin = origin;
            _destination = destination;
            _routes = availableRoutes.ToList();

            _connectedRoutes = new List<ConnectedRoute>();
            _connectedAirportCodes = new HashSet<string>();
        }

        public ConnectedRoute FindShortestRoute()
        {
            _connectedAirportCodes.Add(_origin.Iata);
            _connectedRoutes = FindConnectionsFromOrigin();

            while (_connectedRoutes.Any() && !_connectedAirportCodes.Contains(_destination.Iata))
            {
                List<ConnectedRoute> temporaryConnectedRoutes = new List<ConnectedRoute>();
                foreach (var connectedRoute in _connectedRoutes)
                {
                    List<ConnectedRoute> newRoutes = FindNextConnectionsFromRoute(connectedRoute);
                    temporaryConnectedRoutes.AddRange(newRoutes);
                }
                _connectedRoutes = temporaryConnectedRoutes;
            }

            ConnectedRoute result = _connectedRoutes.Any() ?
                                    _connectedRoutes.FirstOrDefault(r => r.Destination.Equals(_destination)) :
                                    null;
            return result;
        }

        private List<ConnectedRoute> FindConnectionsFromOrigin()
        {
            List<ConnectedRoute> connectedRoutesFromOrigin = new List<ConnectedRoute>();
            List<Route> routesFromOrigin = _routes.Where(r => r.Origin.Equals(_origin)).ToList();
            foreach (var route in routesFromOrigin)
            {
                if (!_connectedAirportCodes.Contains(route.Destination.Iata))
                {
                    connectedRoutesFromOrigin.Add(new ConnectedRoute(route));
                    _connectedAirportCodes.Add(route.Destination.Iata);
                }
            }

            return connectedRoutesFromOrigin;
        }

        private List<ConnectedRoute> FindNextConnectionsFromRoute(ConnectedRoute route)
        {
            var resultConnectedRoutes = new List<ConnectedRoute>();
            List<Route> newPossibleRoutes = _routes.Where(r => r.Origin.Equals(route.Destination)).ToList();

            foreach (var newRoute in newPossibleRoutes)
            {
                if (!_connectedAirportCodes.Contains(newRoute.Destination.Iata))
                {
                    var newConnectedRoute = new ConnectedRoute(route.Routes);
                    newConnectedRoute.AddRoute(newRoute);
                    resultConnectedRoutes.Add(newConnectedRoute);

                    _connectedAirportCodes.Add(newRoute.Destination.Iata);
                }
            }

            return resultConnectedRoutes;
        }


    }
}
