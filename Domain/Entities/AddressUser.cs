using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class AddressUser
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? AddressToShipId { get; set; }

    public virtual AddressToShip AddressToShip { get; set; }

    public virtual User User { get; set; }
}
