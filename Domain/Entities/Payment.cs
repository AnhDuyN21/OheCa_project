using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public string Method { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
