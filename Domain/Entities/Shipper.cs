﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Shipper :BaseEntity
{
    public int? ShipCompanyId { get; set; }

    public string? Phone { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ShipCompany ShipCompany { get; set; }
}
