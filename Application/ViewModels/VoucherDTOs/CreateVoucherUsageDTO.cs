using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.VoucherDTOs
{
    public class CreateVoucherUsageDTO
    {
        public int? VoucherId { get; set; }

        public int? OrderId { get; set; }

        public DateTime? TimeUsage { get; set; }
    }
}
