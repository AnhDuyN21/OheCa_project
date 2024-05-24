using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class ShipCompany: BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Shipper> Shippers { get; set; } = new List<Shipper>();
}
