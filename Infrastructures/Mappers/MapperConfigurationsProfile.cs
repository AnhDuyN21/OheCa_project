using Application.ViewModels.OrderDTOs;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
        }

    }
}
