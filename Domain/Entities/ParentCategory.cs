using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class ParentCategory : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<ChildCategory> ChildCategories { get; set; } = new List<ChildCategory>();
}
