using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Discount : BaseEntity
{
    public double? DiscountPercent { get; set; }

    public int? ProductId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Product Product { get; set; }
}
