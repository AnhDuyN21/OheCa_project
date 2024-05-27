using Application.ViewModels.ProductMaterialDTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ProductDTOs
{
    public class CreateProductDTO
    {
        public string? Name { get; set; }

        public double? UnitPrice { get; set; }

        public double? PriceSold { get; set; }

        public int? Quantity { get; set; }

        public int? QuantitySold { get; set; }

        public int? BrandId { get; set; }

        public string? Country { get; set; }

        public int? Status { get; set; }

        public IFormFile[] Images { get; set; }

    //    public List<ProductMaterialDTO> ProductMaterials { get; set; }
    }
}
