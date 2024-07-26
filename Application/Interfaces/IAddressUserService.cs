using Application.ServiceResponse;
using Application.ViewModels.AddressUserDTOs;
namespace Application.Interfaces
{
    public interface IAddressUserService
    {
        Task<ServiceResponse<ViewAddressUserDTO>> CreateAddressUserAsync(CreateAddressUserDTO createDTO);
        Task<ServiceResponse<ViewAddressUserDTO>> UpdateAddressUserAsync(int id, UpdateAddressUserDTO updateDTO);
        Task<ServiceResponse<ViewAddressUserDTO>> DeleteAddressUserAsync(int id);
        Task<ServiceResponse<IEnumerable<ViewAddressUserDTO>>> ViewAll ();
    }
}
