using Application.ViewModels.AddressToShipDTOs;
using Application.ViewModels.AddressUserDTOs;
using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.PaymentDTOs;
using Application.ViewModels.ShipCompanyDTOs;
using Application.ViewModels.ShipperDTOs;
using Application.ViewModels.UserDTO;
using Application.ViewModels.VoucherDTOs;
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

            //Shipper
            CreateMap<Shipper, ShipperViewDTO>().ReverseMap();
            CreateMap<Shipper, CreateShipperDTO>().ReverseMap();
            CreateMap<Shipper, UpdateShipperDTO>().ReverseMap();

            //AddressToShip
            CreateMap<AddressToShip, ViewAddressToShipDTO>().ReverseMap();
            CreateMap<AddressToShip, CreateAddressToShipDTO>().ReverseMap();
            CreateMap<AddressToShip, UpdateAddressToShipDTO>().ReverseMap();

            //AddressUser
            CreateMap<AddressUser, ViewAddressUserDTO>().ReverseMap();
            CreateMap<AddressUser, CreateAddressUserDTO>().ReverseMap();
            CreateMap<AddressUser, UpdateAddressUserDTO>().ReverseMap();

            //Voucher
            CreateMap<Voucher, ViewVoucherDTO>().ReverseMap();
            CreateMap<Voucher, CreateVoucherDTO>().ReverseMap();
            CreateMap<Voucher, UpdateVoucherDTO>().ReverseMap();
            CreateMap<VoucherUsage, CreateVoucherUsageDTO>().ReverseMap();
        }

    }
}
