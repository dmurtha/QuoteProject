using AutoMapper;
using Quote.Web.ViewModels;
using Quote.Core.Entities.Client;

namespace Quote.Web.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<ClientViewModel, Client>()
                       .ConstructUsing(x => new Client(x.Id, x.ClientName, x.ClientType, x.ClientGuid));


            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientAddressViewModel, ClientAddress>().ReverseMap();
            CreateMap<ClientAddressLevelViewModel, ClientAddressLevel>()
             .ForMember(dest => dest.ClientAddressType, opt => opt.MapFrom(src => src.AddressType));
            CreateMap<ClientAddressLevel, ClientAddressLevelViewModel>()
 .ForMember(dest => dest.AddressType, opt => opt.MapFrom(src => src.ClientAddressType));
            CreateMap<Client, ClientDisplayViewModel>()
                .ForMember(dest => dest.AddressName, opt => opt.MapFrom(src => src.ClientAddress.AddressName))
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.ClientAddress.Id));
            ;
        }

    }
}
