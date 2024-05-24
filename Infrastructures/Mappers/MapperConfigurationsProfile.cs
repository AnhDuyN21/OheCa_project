<<<<<<< HEAD
﻿using Application.ViewModels.ChildCategoriesDTOs;
using Application.ViewModels.DiscountDTOs;
using Application.ViewModels.FeedbackDTOs;
using Application.ViewModels.MaterialDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.ParentCategoriesDTOs;
using Application.ViewModels.ProductDTOs;
using Application.ViewModels.ProductMaterialDTOs;
=======
using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.UserDTO;
>>>>>>> 129aedc82e6d237017c2fe12af7bc8a7b6acc561
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
<<<<<<< HEAD
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductDetailDTO>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Feeback, opt => opt.MapFrom(src => src.Feedbacks))
                .ForMember(dest => dest.Discounts, opt => opt.MapFrom(src => src.Discounts))
                .ForMember(dest => dest.ProductMaterials, opt => opt.MapFrom(src => src.ProductMaterials));
              

            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<Discount, DiscountDTO>().ReverseMap();
            CreateMap<ProductMaterial, ProductMaterialDTO>()
                .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.Material));
            CreateMap<Material, MaterialDTO>()
                .ForMember(dest => dest.ChildCategory, opt => opt.MapFrom(src => src.ChildCategory));
            CreateMap<ChildCategory, ChildCategoriesDTO>()
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory));
            CreateMap<ParentCategory, ParentCategoriesDTO>().ReverseMap();
               
            //  CreateMap<Orders, OrderResponse>()
            // .ForMember(dest => dest.Itemss, opt => opt.MapFrom(src => src.OrderDetails))
            //    .ReverseMap();
=======
            //Users
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, RegisterUserDTO>().ReverseMap();



            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDTO>().ReverseMap();
>>>>>>> 129aedc82e6d237017c2fe12af7bc8a7b6acc561
        }

    }
}
