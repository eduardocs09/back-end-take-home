using AutoMapper;
using Routes.API.ViewModels;
using Routes.Core.Entities;

namespace Routes.API.Profiles
{
    public class AirportViewModelProfile : Profile
    {
        public AirportViewModelProfile()
        {
            CreateMap<Airport, AirportViewModel>()
                .ForMember(vm => vm.Name, opt => opt.MapFrom(a => a.Name))
                .ForMember(vm => vm.Code, opt => opt.MapFrom(a => a.Iata))
                .ForMember(vm => vm.City, opt => opt.MapFrom(a => a.City))
                .ForMember(vm => vm.Country, opt => opt.MapFrom(a => a.Country));
        }
    }
}
