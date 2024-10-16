using AutoMapper;
using BooknGo.Data.Models;
using BooknGo.DTOs;

namespace BooknGo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Booking, BookingDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
        }
    }
}
