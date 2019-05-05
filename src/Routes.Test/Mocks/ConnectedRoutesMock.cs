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
            //Airports 0 -> 1 -> 3
            new ConnectedRoute(new List<Route>()
            {
                RoutesMock.Routes[0],
                RoutesMock.Routes[2]
            }),
            //Airports 0 -> 1 -> 3 -> 7
            new ConnectedRoute(new List<Route>(){
                RoutesMock.Routes[0],
                RoutesMock.Routes[2],
                RoutesMock.Routes[6]
            }),
            //Airports 0 -> 2 -> 6
            new ConnectedRoute(new List<Route>()
            {
                RoutesMock.Routes[1],
                RoutesMock.Routes[5]
            }),
            //Airports 0 -> 1 -> 4 -> 6
            new ConnectedRoute(new List<Route>(){
                RoutesMock.Routes[0],
                RoutesMock.Routes[3],
                RoutesMock.Routes[7]
            })
        };
    }
}
