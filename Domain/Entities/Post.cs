using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Post : BaseEntity
{
    public string Title { get; set; }

    public string Content { get; set; }

    public int? LikeQuantity { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User User { get; set; }
}
