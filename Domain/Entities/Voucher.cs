using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Voucher
{
    public int Id { get; set; }

    public double? Discount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? TotalQuantityVoucher { get; set; }

    public int? UsedQuanity { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<VoucherUsage> VoucherUsages { get; set; } = new List<VoucherUsage>();
}
