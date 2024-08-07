﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string? Name { get; set; }

    public double? UnitPrice { get; set; }

    public double? PriceSold { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public int? QuantitySold { get; set; }

    public int? BrandId { get; set; }

    public string? Country { get; set; }
    public float? DiscountPercent { get; set; }

    public int? Status { get; set; }

    public virtual Brand Brand { get; set; }

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();
}
