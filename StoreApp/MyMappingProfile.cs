using AutoMapper;
using StoreApp.AppServices.City.Dtos;
using StoreApp.AppServices.Country.Dtos;
using StoreApp.Entities;

namespace StoreApp
{
    public class MyMappingProfile:Profile
    {

        public MyMappingProfile()
        {
            CreateMap<Country,CreateCountryDto>().ReverseMap();

            CreateMap<Country, CountryDto>();
                 //.ForMember(d => d.Name, act => act.MapFrom(s => s.Name));


            CreateMap<City, CreateCityDto>().ReverseMap();

            CreateMap<City, CityDto>().ForMember(d=>d.CountryName, cont=> cont.MapFrom(s=>s.Country!.Name ?? ""));
               

        }
    }
}
