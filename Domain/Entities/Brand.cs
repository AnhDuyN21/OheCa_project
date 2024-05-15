using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
