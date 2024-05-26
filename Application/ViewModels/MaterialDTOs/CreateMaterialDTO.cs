using Application.ViewModels.ChildCategoriesDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.MaterialDTOs
{
    public class CreateMaterialDTO
    {
        public int? ChildCategoryId { get; set; }
        public CreateChildCategoryDTO ChildCategory { get; set; }

    }
}
