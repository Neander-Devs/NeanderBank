using AutoMapper;
using NeanderBank.Business.Models;

namespace NeanderBank.Api.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CostumerDTO, Costumer>();
            CreateMap<Costumer, CostumerDTO>();
        }
    }
}
