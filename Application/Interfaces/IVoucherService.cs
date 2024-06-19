using Application.ServiceResponse;
using Application.ViewModels.VoucherDTOs;


namespace Application.Interfaces
{
    public interface IVoucherService
    {
        Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> GetVoucherAsync();
        Task<ServiceResponse<ViewVoucherDTO>> GetVoucherByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> GetVoucherIsValidAsync();
        Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> GetVoucherIsUsedByOrderByUserIDAsync(int orderId);
        Task<ServiceResponse<ViewVoucherDTO>> CreateVoucherAsync(CreateVoucherDTO createDTO);
        Task<ServiceResponse<ViewVoucherDTO>> UpdateVoucherAsync(int id, UpdateVoucherDTO updateDTO);
        Task<ServiceResponse<ViewVoucherDTO>> DeleteVoucherAsync(int id);
        Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> GetSortedVouchersAsync(string sortName);

        Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> AddVoucherForOrderAsync(List<CreateVoucherUsageDTO> createDTOs);
        //Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> UpdateVoucherForOrderAsync(List<CreateVoucherUsageDTO> createDTOs, int orderId);
        //Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> DeletedVoucherForOrderAsync(int orderid, int voucherid);
    }
}
