﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.OrderDetailDTOs
{
    public class OrderDetailViewDTO
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }

        public int? Quantity { get; set; }

        public double? Price { get; set; }

        public virtual Product Product { get; set; }
    }
}
