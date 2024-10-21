using AutoMapper;
using BooknGoApi.Data.Models;
using BooknGoApi.Dtos;

namespace BooknGoApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Availability, AvailabilityDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Resource, ResourceDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
