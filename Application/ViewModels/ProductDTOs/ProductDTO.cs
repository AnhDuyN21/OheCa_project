﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public double? UnitPrice { get; set; }

        public float? DiscountPercent { get; set; }

        public double? PriceSold { get; set; }

        public int? Quantity { get; set; }

        public int? QuantitySold { get; set; }

        public string? BrandName { get; set; }

        public int? BrandId { get; set; }
        public string Country { get; set; }

        public int? Status { get; set; }

        public string? ImageLink { get; set; }


    }
}
