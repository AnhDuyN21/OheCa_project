using Application.ServiceResponse;
using Application.ViewModels.OrderDetailDTOs;

namespace Application.Interfaces
{
    public interface IOrderDetailService
    {
        Task<ServiceResponse<IEnumerable<OrderDetailDTO>>> GetOrderDetailsAsync();
        Task<ServiceResponse<IEnumerable<OrderDetailDTO>>> GetOrderDetailByOrderIdsAsync(int orderId);
        Task<ServiceResponse<OrderDetailDTO>> GetOrderDetailByIdAsync(int orderDetailId);
        Task<ServiceResponse<OrderDetailDTO>> CreateOrderDetailAsync(CreateOrderDetailDTO orderDetail);
        Task<ServiceResponse<OrderDetailDTO>> UpdateOrderDetailAsync(int id, UpdateOrderDetailDTO order);
    }
}
