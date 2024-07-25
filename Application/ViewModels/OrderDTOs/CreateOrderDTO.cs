﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.OrderDTOs
{
    public class CreateOrderDTO
    {
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
    }

    public class CheckoutDTO
    {
        public int? UserId { get; set; }

        //public int? ShipperId { get; set; }

        //public DateTime? OrderDate { get; set; }

        //public DateTime? ShipDate { get; set; }

        //public DateTime? ReceiveDate { get; set; }

        public double? FreightCost { get; set; }

        //public int? IsConfirm { get; set; }

        //public int? Status { get; set; }

        public int? PaymentId { get; set; }

        //public int? StatusOfPayment { get; set; }

        public int? AddressToShipId { get; set; }

        //public double? TotalPrice { get; set; }

        //public int? OrderId { get; set; }

        public virtual List<Cart> Carts { get; set; }
    }

    public class Cart
    {
        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        //public double? Price { get; set; }
    }
}
