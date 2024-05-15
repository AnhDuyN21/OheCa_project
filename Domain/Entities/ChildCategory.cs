using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ChildCategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ParentCategoryId { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ParentCategory ParentCategory { get; set; }
}
