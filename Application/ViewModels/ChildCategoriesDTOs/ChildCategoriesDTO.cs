using Application.ViewModels.ParentCategoriesDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ChildCategoriesDTOs
{
    public class ChildCategoriesDTO
    {
        public string Name { get; set; }

        public ParentCategoriesDTO ParentCategory { get; set; }
    }
}

