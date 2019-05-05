using AutoMapper;
using Routes.API.ViewModels;
using Routes.Core.Entities;

namespace Routes.API.Profiles
{
    public class AirlineViewModelProfile : Profile
    {
        public AirlineViewModelProfile()
        {
            CreateMap<Airline, AirlineViewModel>()
                .ForMember(vm => vm.Name, opt => opt.MapFrom(a => a.Name))
                .ForMember(vm => vm.Code, opt => opt.MapFrom(a => a.TwoDigitCode));
        }
    }
}
