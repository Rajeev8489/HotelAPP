using AutoMapper;
using HotelAppUI.Model;
using HotelAppUI.Models;
namespace HotelAppUI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Booking, BookingDTO>();
            CreateMap<BookingDTO, Booking>();
        }
    }
}
