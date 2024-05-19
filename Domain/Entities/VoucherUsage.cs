
namespace Domain.Entities;

public class VoucherUsage : BaseEntity
{
    public int? VoucherId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? TimeUsage { get; set; }

    public virtual Order Order { get; set; }

    public virtual Voucher Voucher { get; set; }
}
