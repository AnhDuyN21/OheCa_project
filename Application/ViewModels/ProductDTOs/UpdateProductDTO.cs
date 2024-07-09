using Application.ViewModels.ImageProductDTOs;
using Application.ViewModels.ProductMaterialDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string? Name { get; set; }

        public double? UnitPrice { get; set; }

        public double? PriceSold { get; set; }

        public int? Quantity { get; set; }

        public int? QuantitySold { get; set; }

        public string? Description { get; set; }
        public int? BrandId { get; set; }

        public string? Country { get; set; }

        public int? Status { get; set; }
        public List<CreateProductMaterialDTO> ProductMaterials { get; set; }

        //  public IFormFile Description { get; set; }
        public List<CreateImageDTO> Images { get; set; }
    }
}
