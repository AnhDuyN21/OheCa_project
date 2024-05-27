using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.ChildCategoriesDTOs;
using Application.ViewModels.DiscountDTOs;
using Application.ViewModels.FeedbackDTOs;
using Application.ViewModels.MaterialDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.UserDTO;
using Application.ViewModels.ParentCategoriesDTOs;
using Application.ViewModels.ProductDTOs;
using Application.ViewModels.ProductMaterialDTOs;
using AutoMapper;
using Domain.Entities;
using Application.ViewModels.ImageProductDTOs;

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


            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ImageLink, opt => opt.MapFrom(src => src.Images.FirstOrDefault(img => img.Thumbnail == true).ImageLink));
            CreateMap<Product, ProductDetailDTO>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Feeback, opt => opt.MapFrom(src => src.Feedbacks))
                .ForMember(dest => dest.Discounts, opt => opt.MapFrom(src => src.Discounts))
                .ForMember(dest => dest.ProductMaterials, opt => opt.MapFrom(src => src.ProductMaterials))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
              

            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDTO>().ReverseMap();
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<Discount, DiscountDTO>().ReverseMap();
            //CreateMap<ProductMaterialDTO, ProductMaterial>()
            //    .ForMember(dest => dest.Detail, opt => opt.MapFrom(src => src.Detail))
            //    .ForMember(dest => dest.MaterialId, opt => opt.MapFrom(src => src.MaterialId))
            //    .ForMember(dest => dest.Material, opt => opt.Ignore())  // Assuming Material is managed separately
            //    .ForMember(dest => dest.Product, opt => opt.Ignore())   // Assuming Product is managed separately
            //    .ForMember(dest => dest.ProductId, opt => opt.Ignore()) // Ignoring ProductId, assuming it will be set separately
            //    .ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<ProductMaterial, ProductMaterialDTO>()                              
                .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.Material));

            CreateMap<CreateProductMaterialDTO, ProductMaterial>()
                .ForMember(dest => dest.Material, opt => opt.Ignore());


            CreateMap<Material, MaterialDTO>()
                .ForMember(dest => dest.ChildCategory, opt => opt.MapFrom(src => src.ChildCategory));
            CreateMap<ChildCategory, ChildCategoriesDTO>()
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory));
            CreateMap<ParentCategory, ParentCategoriesDTO>().ReverseMap();
            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<CreateProductDTO, Product>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.ProductMaterials, opt => opt.MapFrom(src => src.ProductMaterials));
            CreateMap<UpdateProductDTO, Product>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.ProductMaterials, opt => opt.MapFrom(src => src.ProductMaterials));
            CreateMap<CreateImageDTO, Image>()
                .ForMember(dest => dest.ImageLink, opt => opt.Ignore());
            //        CreateMap<CreateProductMaterialDTO, ProductMaterial>().ReverseMap();
            CreateMap<CreateMaterialDTO, Material>()
                .ForMember(dest => dest.ChildCategoryId, opt => opt.Ignore());
            CreateMap<CreateChildCategoryDTO, ChildCategoriesDTO>()
                .ForMember(dest => dest.ParentCategory, opt => opt.Ignore());

            //  CreateMap<Orders, OrderResponse>()
            // .ForMember(dest => dest.Itemss, opt => opt.MapFrom(src => src.OrderDetails))
            //    .ReverseMap();
        }

    }
}
