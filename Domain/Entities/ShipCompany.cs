using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ShipCompany
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Shipper> Shippers { get; set; } = new List<Shipper>();
}
