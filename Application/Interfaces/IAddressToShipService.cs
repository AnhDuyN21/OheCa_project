using Application.ServiceResponse;
using Application.ViewModels.AddressToShipDTOs;

namespace Application.Interfaces
{
    public interface IAddressToShipService
    {
        Task<ServiceResponse<IEnumerable<ViewAddressToShipDTO>>> GetAddressToShipAsync();
        Task<ServiceResponse<ViewAddressToShipDTO>> GetAddressToShipByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<ViewAddressToShipDTO>>> searchAddressToShipsByNameAsync(string name);
        Task<ServiceResponse<IEnumerable<ViewAddressToShipDTO>>> GetAddressToShipByUserIDAsync(int userID);
        Task<ServiceResponse<ViewAddressToShipDTO>> CreateAddressToShipAsync(CreateAddressToShipDTO createDTO);
        Task<ServiceResponse<ViewAddressToShipDTO>> UpdateAddressToShipAsync(int id, UpdateAddressToShipDTO updateDTO);
        Task<ServiceResponse<ViewAddressToShipDTO>> DeleteAddressToShipAsync(int id);
        Task<ServiceResponse<IEnumerable<ViewAddressToShipDTO>>> GetSortedAddressToShipsAsync(string sortName);
    }
}
