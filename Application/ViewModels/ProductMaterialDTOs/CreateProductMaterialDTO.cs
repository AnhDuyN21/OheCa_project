using Application.ViewModels.MaterialDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ProductMaterialDTOs
{
    public class CreateProductMaterialDTO
    {
        public string Detail { get; set; }

        public int? MaterialId { get; set; }
        public CreateMaterialDTO Material { get; set; }
        
    }
}
