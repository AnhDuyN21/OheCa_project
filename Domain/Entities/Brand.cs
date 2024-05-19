using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
