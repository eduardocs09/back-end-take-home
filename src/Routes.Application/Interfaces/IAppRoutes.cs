using Routes.Core.Entities;

namespace Routes.Application.Interfaces
{
    public interface IAppRoutes
    {
        ConnectedRoute FindShortestRoute(string origin, string destination);
    }
}
