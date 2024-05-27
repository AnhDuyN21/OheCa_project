using Application.ServiceResponse;
using Application.ViewModels.OrderDetailDTOs;

namespace Application.Interfaces
{
    public interface IOrderDetailService
    {
        Task<ServiceResponse<IEnumerable<OrderDetailViewDTO>>> GetOrderDetailsAsync();
        Task<ServiceResponse<IEnumerable<OrderDetailDTO>>> GetOrderDetailByOrderIdsAsync(int orderDetailId);
        Task<ServiceResponse<OrderDetailDTO>> GetOrderDetailByIdAsync(int orderDetailId);
        Task<ServiceResponse<OrderDetailDTO>> CreateOrderDetailAsync(CreateOrderDetailDTO orderDetail);
        Task<ServiceResponse<OrderDetailDTO>> UpdateOrderDetailAsync(int id, UpdateOrderDetailDTO orderDetail);
        Task<ServiceResponse<IEnumerable<OrderDetailViewDTO>>> DeletedOrderDetailRange(int orderid);
    }
}
