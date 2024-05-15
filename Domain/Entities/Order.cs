using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ShipperId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? ShipDate { get; set; }

    public DateTime? ReceiveDate { get; set; }

    public double? FreightCost { get; set; }

    public int? IsConfirm { get; set; }

    public int? Status { get; set; }

    public int? PaymentId { get; set; }

    public int? StatusOfPayment { get; set; }

    public int? AddressToShipId { get; set; }

    public double? TotalPrice { get; set; }

    public virtual AddressToShip AddressToShip { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Payment Payment { get; set; }

    public virtual Shipper Shipper { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<VoucherUsage> VoucherUsages { get; set; } = new List<VoucherUsage>();
}
