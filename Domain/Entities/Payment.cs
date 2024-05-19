using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Payment : BaseEntity
{
    public string Method { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
