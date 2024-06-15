using Application.ViewModels.AddressToShipDTOs;

namespace Application.ViewModels.AddressUserDTOs
{
    public class ViewAddressUserDTO
    {
        public virtual IEnumerable<ViewAddressToShipDTO> AddressToShipDTOs { get; set; }

        public virtual UserDTO.UserDTO User { get; set; }
    }
}
