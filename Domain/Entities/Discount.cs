using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Discount
{
    public int Id { get; set; }

    public double? Discount1 { get; set; }

    public int? ProductId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Status { get; set; }

    public virtual Product Product { get; set; }
}
