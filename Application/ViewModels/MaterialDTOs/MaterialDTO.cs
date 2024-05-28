using Application.ViewModels.ChildCategoriesDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.MaterialDTOs
{
    public class MaterialDTO
    {
        
        public string Name { get; set; }

        public int? ChildCategoryId { get; set; }
        public ChildCategoriesDTO ChildCategory { get; set; }
    }
}
