using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ShipperDTOs
{
    public class UpdateShipperDTO
    {
        public int? ShipCompanyId { get; set; }

        public string? Phone { get; set; }

        public string? Name { get; set; }
    }
}
