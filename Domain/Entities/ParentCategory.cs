using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ParentCategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<ChildCategory> ChildCategories { get; set; } = new List<ChildCategory>();
}
