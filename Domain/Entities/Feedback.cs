using System;

namespace Domain.Entities;

public  class Feedback : BaseEntity
{
    public int? UserId { get; set; }

    public string Content { get; set; }

    public int? Rate { get; set; }

    public int? ProductId { get; set; }

    public virtual Product Product { get; set; }

    public virtual User User { get; set; }
}
