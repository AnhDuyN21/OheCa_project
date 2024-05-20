using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Voucher : BaseEntity
{
    public double? Discount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? TotalQuantityVoucher { get; set; }

    public int? UsedQuanity { get; set; }

    public virtual ICollection<VoucherUsage> VoucherUsages { get; set; } = new List<VoucherUsage>();
}
