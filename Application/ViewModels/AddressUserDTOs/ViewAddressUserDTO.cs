using Application.ViewModels.AddressToShipDTOs;
using Domain.Entities;

namespace Application.ViewModels.AddressUserDTOs
{
    public class ViewAddressUserDTO
    {
        public int? UserId { get; set; }

        public int? AddressToShipId { get; set; }
    }
}
