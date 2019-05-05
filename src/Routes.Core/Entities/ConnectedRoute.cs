using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Routes.Core.Entities
{
    public class ConnectedRoute
    {
        public Airport Origin { get; private set; }
        public Airport Destination { get; private set; }
        private List<Route> _routes;
        public IReadOnlyCollection<Route> Routes => _routes;

        public ConnectedRoute()
        { }

        public ConnectedRoute(Route route)
        {
            _routes = new List<Route> { route };
            Origin = route.Origin;
            Destination = route.Destination;
        }

        public ConnectedRoute(IEnumerable<Route> routes)
        {
            _routes = routes.ToList();
            Origin = _routes.First().Origin;
            Destination = _routes.Last().Destination;
        }

        public void AddRoute(Route route)
        {
            _routes.Add(route);
            Destination = _routes.Last().Destination;
        }

        public override bool Equals(object obj)
        {
            bool equals = obj is ConnectedRoute connectedRoute &&
                Origin == connectedRoute.Origin &&
                Destination == connectedRoute.Destination &&
                _routes.Count == connectedRoute.Routes.Count;

            if (equals)
            {
                for (int index = 0; index < _routes.Count; index++)
                {
                    Route route = ((ConnectedRoute)obj).Routes.ElementAt(index);
                    if (!_routes[index].Equals(route))
                    {
                        equals = false;
                    }
                }
            }

            return equals;
        }
    }
}
