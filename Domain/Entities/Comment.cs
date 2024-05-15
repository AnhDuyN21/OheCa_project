using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public int? CommentBy { get; set; }

    public string Content { get; set; }

    public int? PostId { get; set; }

    public DateTime? CommentDate { get; set; }

    public int? Status { get; set; }

    public virtual Post Post { get; set; }

    public virtual ICollection<ReportOfUser> ReportOfUsers { get; set; } = new List<ReportOfUser>();
}
