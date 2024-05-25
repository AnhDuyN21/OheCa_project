using Application.ViewModels.DiscountDTOs;
using Application.ViewModels.FeedbackDTOs;
using Application.ViewModels.ImageProductDTOs;
using Application.ViewModels.ProductMaterialDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ProductDTOs
{
    public class ProductDetailDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public double? UnitPrice { get; set; }

        public double? PriceSold { get; set; }

        public int? Quantity { get; set; }

        public int? QuantitySold { get; set; }

       // public int? BrandId { get; set; }

        public string Country { get; set; }

        public int? Status { get; set; }

        public string BrandName { get; set; }

    //    public double? DiscountPercent { get; set; }

        public List<FeedbackDTO>  Feeback { get; set; }

        public List<DiscountDTO> Discounts { get; set; }


        public List<ImageDTO> Images { get; set; }

        public List<ProductMaterialDTO> ProductMaterials { get; set; }
    }
}
