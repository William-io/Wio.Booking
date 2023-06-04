using AutoMapper;
using Wio.Booking.API.ViewModels;
using Wio.Booking.Business.Models;

namespace Wio.Booking.API.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<Supplier, SupplierViewModel>().ReverseMap();
        CreateMap<Address, AddressViewModel>().ReverseMap();
        CreateMap<CarRental, CarRentalViewModel>();
        
        // CreateMap<CarRentalImageViewModel, CarRental>().ReverseMap();
        // CreateMap<CarRental, CarRentalViewModel>()
        //     .ForMember(dest => dest.NameSupplier, opt => opt.MapFrom(src => src.Supplier.Name));
    }
}
