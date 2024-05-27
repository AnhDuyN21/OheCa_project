using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.PaymentDTOs;
using Application.ViewModels.ShipCompanyDTOs;
using Application.ViewModels.UserDTO;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            //Orders
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
            //Users
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, RegisterUserDTO>().ReverseMap();


            //OrderDetail
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailViewDTO>().ReverseMap();

            //Payment
            CreateMap<Payment, PaymentViewDTO>().ReverseMap();
            CreateMap<Payment, CreatePaymentDTO>().ReverseMap();
            CreateMap<Payment, UpdatePaymentDTO>().ReverseMap();

            //ShipCompany
            CreateMap<ShipCompany, ShipCompanyViewDTO>().ReverseMap();
            CreateMap<ShipCompany, CreateShipCompanyDTO>().ReverseMap();
            CreateMap<ShipCompany, UpdateShipCompanyDTO>().ReverseMap();

        }

    }
}
