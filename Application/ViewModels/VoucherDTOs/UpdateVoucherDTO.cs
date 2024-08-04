using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.VoucherDTOs
{
    public class UpdateVoucherDTO
    {
        public double? Discount { get; set; }

        //public DateTime? StartTime { get; set; }

        //public DateTime? EndTime { get; set; }

        public int? TotalQuantityVoucher { get; set; }

        public int? UsedQuanity { get; set; }
    }
}
