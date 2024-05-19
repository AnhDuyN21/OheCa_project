using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class OrderDetail : BaseEntity
{
    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
}
