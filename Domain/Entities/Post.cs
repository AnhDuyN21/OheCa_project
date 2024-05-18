using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int? LikeQuantity { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User User { get; set; }
}
