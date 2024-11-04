using AutoMapper;
using BooknGoApi.Data.Models;
using BooknGoApi.Dtos;

namespace BooknGoApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Booking <-> BookingDto
            CreateMap<Booking, BookingDto>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
                .ReverseMap();

            // Map Customer <-> CustomerDto
            CreateMap<Customer, CustomerDto>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
                .ReverseMap();
        }
    }
}
