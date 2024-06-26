﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class ProductMaterial : BaseEntity
{
    public string? Detail { get; set; }

    public int? ProductId { get; set; }

    public int? MaterialId { get; set; }

    public virtual Material Material { get; set; }

    public virtual Product Product { get; set; }
}
