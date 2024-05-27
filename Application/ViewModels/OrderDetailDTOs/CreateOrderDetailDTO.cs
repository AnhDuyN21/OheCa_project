﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.OrderDetailDTOs
{
    public class CreateOrderDetailDTO
    {
        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public double? Price { get; set; }
    }
}
