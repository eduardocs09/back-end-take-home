using System;
using System.Collections.Generic;
using System.Text;
using Routes.Core.Entities;

namespace Routes.Test.Mocks
{
    public class ConnectedRoutesMock
    {
        public static List<ConnectedRoute> SingleRouteConnectedRoutes = new List<ConnectedRoute>()
        {
            new ConnectedRoute(RoutesMock.Routes[0])
        };

        public static List<ConnectedRoute> MultipleRouteConnectedRoutes = new List<ConnectedRoute>()
        {
            new ConnectedRoute(new List<Route>()
            {
                RoutesMock.Routes[0],
                RoutesMock.Routes[2]
            })
        };
    }
}
