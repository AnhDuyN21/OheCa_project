using Application.ViewModels.ChildCategoriesDTOs;
using Application.ViewModels.DiscountDTOs;
using Application.ViewModels.FeedbackDTOs;
using Application.ViewModels.MaterialDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.ParentCategoriesDTOs;
using Application.ViewModels.ProductDTOs;
using Application.ViewModels.ProductMaterialDTOs;
using AutoMapper;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductDetailDTO>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Feeback, opt => opt.MapFrom(src => src.Feedbacks))
                .ForMember(dest => dest.Discounts, opt => opt.MapFrom(src => src.Discounts))
                .ForMember(dest => dest.ProductMaterials, opt => opt.MapFrom(src => src.ProductMaterials));
              

            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<Discount, DiscountDTO>().ReverseMap();
            CreateMap<ProductMaterial, ProductMaterialDTO>()
                .ForMember(dest => dest.MaterialId, opt => opt.MapFrom(src => src.MaterialId));
            CreateMap<Material, MaterialDTO>()
                .ForMember(dest => dest.ChildCategoryId, opt => opt.MapFrom(src => src.ChildCategoryId));
            CreateMap<ChildCategory, ChildCategoriesDTO>()
                .ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(src => src.ParentCategoryId));
            CreateMap<ParentCategory, ParentCategoriesDTO>().ReverseMap();
               
            //  CreateMap<Orders, OrderResponse>()
            // .ForMember(dest => dest.Itemss, opt => opt.MapFrom(src => src.OrderDetails))
            //    .ReverseMap();
        }

    }
}
