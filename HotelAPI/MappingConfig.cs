using AutoMapper;
using HotelAPI.Model;

namespace HotelAPI
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
