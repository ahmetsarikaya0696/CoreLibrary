using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreditCard, CustomerDto>();

            CreateMap<Customer, CustomerDto>()
                .IncludeMembers(x => x.CreditCard)
                .ForMember(destination => destination.Isim, options => options.MapFrom(source => source.Name))
                .ForMember(destination => destination.Eposta, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.Yas, options => options.MapFrom(source => source.Age))
                //.ForMember(destination => destination.FullName, options => options.MapFrom(source => source.FullName2()))
                //.ForMember(destination => destination.CCNumber, options => options.MapFrom(source => source.CreditCard.Number))
                //.ForMember(destination => destination.CCValidDate, options => options.MapFrom(source => source.CreditCard.ValidDate))
                .ReverseMap();
        }

        // metotlar maplenirken GetFullName
        // maplenen prop FullName şeklinde girilirse direkt olarak maplenir.
    }
}
