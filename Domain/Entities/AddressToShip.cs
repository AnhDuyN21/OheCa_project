using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class AddressToShip : BaseEntity
{
    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Ward { get; set; }

    public string? DetailAddress { get; set; }

    public string? Phone { get; set; }

    public string? CustomerName { get; set; }

    public virtual ICollection<AddressUser> AddressUsers { get; set; } = new List<AddressUser>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
