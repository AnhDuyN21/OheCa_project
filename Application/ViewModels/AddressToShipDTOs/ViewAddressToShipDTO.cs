using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AddressToShipDTOs
{
    public class ViewAddressToShipDTO
    {
        public int Id { get; set; }
        public string? Province { get; set; }

        public string? District { get; set; }

        public string? Ward { get; set; }

        public string? DetailAddress { get; set; }

        public string? Phone { get; set; }

        public string? CustomerName { get; set; }
    }
}
