using AutoMapper;
using Routes.API.ViewModels;
using Routes.Core.Entities;

namespace Routes.API.Profiles
{
    public class ConnectionViewModelProfile : Profile
    {
        public ConnectionViewModelProfile()
        {
            CreateMap<Route, ConnectionViewModel>()
                .ForMember(vm => vm.Airline, opt => opt.MapFrom(r => r.Airline))
                .ForMember(vm => vm.Origin, opt => opt.MapFrom(r => r.Origin))
                .ForMember(vm => vm.Destination, opt => opt.MapFrom(r => r.Destination));
        }
    }
}
