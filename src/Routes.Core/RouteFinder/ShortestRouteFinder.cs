using System;
using System.Collections.Generic;
using System.Linq;
using Routes.Core.Entities;

namespace Routes.Core.RouteFinder
{
    public class ShortestRouteFinder
    {
        public ShortestRouteFinder()
        {}

        public ShortestRouteFinder(Airport origin, Airport destination, IEnumerable<Route> availableRoutes)
        { }

        public ConnectedRoute GetRoute()
        {
            return null;
        }
    }
}
