using Application.ViewModels.MaterialDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ProductMaterialDTOs
{
    public class ProductMaterialDTO
    {
        public int Id { get; set; }
        public string Detail { get; set; }

        public int? MaterialId { get; set; }
        public MaterialDTO Material { get; set; }
    }
}
