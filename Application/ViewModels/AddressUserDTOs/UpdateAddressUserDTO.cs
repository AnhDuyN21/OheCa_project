using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AddressUserDTOs
{
    public class UpdateAddressUserDTO
    {
        public int? UserId { get; set; }

        public int? AddressToShipId { get; set; }
    }
}
