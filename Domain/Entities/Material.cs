using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ChildCategoryId { get; set; }

    public virtual ChildCategory ChildCategory { get; set; }

    public virtual ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();
}
