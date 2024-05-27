using Application.ServiceResponse;
using Application.ViewModels.ShipCompanyDTOs;

namespace Application.Interfaces
{
    public interface IShipCompanyService
    {
        Task<ServiceResponse<IEnumerable<ShipCompanyViewDTO>>> GetShipCompanysAsync();
        Task<ServiceResponse<ShipCompanyViewDTO>> GetShipCompanyByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<ShipCompanyViewDTO>>> searchShipCompanyByNameAsync(string name);
        Task<ServiceResponse<ShipCompanyViewDTO>> CreateShipCompanyAsync(CreateShipCompanyDTO createDTO);
        Task<ServiceResponse<ShipCompanyViewDTO>> UpdateShipCompanyAsync(int id, UpdateShipCompanyDTO updateDTO);
        Task<ServiceResponse<ShipCompanyViewDTO>> DeleteShipCompanyAsync(int id);
        Task<ServiceResponse<IEnumerable<ShipCompanyViewDTO>>> GetSortedShipCompanysAsync(string sortName);
    }
}
