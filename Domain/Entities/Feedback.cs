using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Feedback
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? Content { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? Rate { get; set; }

    public int? ProductId { get; set; }

    public virtual Product Product { get; set; }

    public virtual User User { get; set; }
}
