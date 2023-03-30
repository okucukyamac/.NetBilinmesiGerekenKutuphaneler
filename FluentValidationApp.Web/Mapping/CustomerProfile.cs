using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<CreditCard, CustomerDto>();

            CreateMap<Customer, DifferentCustomerDto>().IncludeMembers(a=>a.CreditCard)
                .ForMember(dest => dest.Isim, opt => opt.MapFrom(a => a.Name))
                .ForMember(dest => dest.Eposta, opt => opt.MapFrom(a => a.Email))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(a => a.Age)).ReverseMap();
        }
    }
}