using Application.ServiceResponse;
using Application.ViewModels.PaymentDTOs;

namespace Application.Interfaces
{
    public interface IPaymentService
    {
        Task<ServiceResponse<IEnumerable<PaymentViewDTO>>> GetPaymentsAsync();
        Task<ServiceResponse<PaymentViewDTO>> GetPaymentByIdAsync(int paymentId);
        Task<ServiceResponse<IEnumerable<PaymentViewDTO>>> searchPaymentByNameAsync(string name);
        Task<ServiceResponse<PaymentViewDTO>> CreatePaymentAsync(CreatePaymentDTO createPaymentDTO);
        Task<ServiceResponse<PaymentViewDTO>> UpdatePaymentAsync(int id, UpdatePaymentDTO updatePaymentDTO);
        Task<ServiceResponse<PaymentViewDTO>> DeletePaymentAsync(int id);
        Task<ServiceResponse<IEnumerable<PaymentViewDTO>>> GetSortedPaymentsAsync(string sortName);
    }
}
