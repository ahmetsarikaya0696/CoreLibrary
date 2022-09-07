using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.Mappings
{
    public class EventDateProfile : Profile
    {
        public EventDateProfile()
        {
            CreateMap<EventDateDto, EventDate>()
                .ForMember(
                    destination => destination.Date,
                    options => options.MapFrom(source => new DateTime(source.Year, source.Month, source.Day)));

            // projection işleminde reverseMap komutu çalışmaz

            CreateMap<EventDate, EventDateDto>()
                .ForMember(
                    destination => destination.Year,
                    options => options.MapFrom(source => source.Date.Year))
                .ForMember(
                    destination => destination.Month,
                    options => options.MapFrom(source => source.Date.Month))
                .ForMember(
                    destination => destination.Day,
                    options => options.MapFrom(source => source.Date.Day));
        }
    }
}