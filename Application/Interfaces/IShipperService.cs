using Application.ServiceResponse;
using Application.ViewModels.ShipperDTOs;


namespace Application.Interfaces
{
    public interface IShipperService
    {
        Task<ServiceResponse<IEnumerable<ShipperViewDTO>>> GetShippersAsync();
        Task<ServiceResponse<ShipperViewDTO>> GetShipperByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<ShipperViewDTO>>> searchShippersByNameAsync(string name);
        Task<ServiceResponse<IEnumerable<ShipperViewDTO>>> GetShippersByCompanyAsync(int companyID);
        Task<ServiceResponse<ShipperViewDTO>> CreateShipperAsync(CreateShipperDTO createDTO);
        Task<ServiceResponse<ShipperViewDTO>> UpdateShippperAsync(int id, UpdateShipperDTO updateDTO);
        Task<ServiceResponse<ShipperViewDTO>> DeleteShipperAsync(int id);
        Task<ServiceResponse<IEnumerable<ShipperViewDTO>>> GetSortedShippersAsync(string sortName);
    }
}
