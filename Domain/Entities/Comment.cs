using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Comment : BaseEntity
{

    public string Content { get; set; }

    public int? PostId { get; set; }

    public virtual User User { get; set; }

    public virtual Post Post { get; set; }

    public virtual ICollection<ReportOfUser> ReportOfUsers { get; set; } = new List<ReportOfUser>();
}
