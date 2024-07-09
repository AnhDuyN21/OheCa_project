using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public partial class Post : BaseEntity
{
    public string? Title { get; set; }

    public string? Content { get; set; }

    public int? LikeQuantity { get; set; }

    public int UserId {  get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public User? User { get; set; }
}
