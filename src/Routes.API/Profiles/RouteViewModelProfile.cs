using AutoMapper;
using Routes.API.ViewModels;
using Routes.Core.Entities;

namespace Routes.API.Profiles
{
    public class RouteViewModelProfile : Profile
    {
        public RouteViewModelProfile()
        {
            CreateMap<ConnectedRoute, RouteViewModel>()
                .ForMember(vm => vm.Connections, opt => opt.MapFrom(c => c.Routes));
        }
    }
}
