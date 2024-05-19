using Application.ServiceResponse;
using Application.ViewModels.OrderDTOs;


namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrders();
        Task<ServiceResponse<OrderDTO>> GetOrderById(int orderId);
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrderByUserID(int userId);
        Task<ServiceResponse<OrderDTO>> CreateOrder(CreateOrderDTO order);
        Task<ServiceResponse<OrderDTO>> UpdateOrder(UpdateOrderDTO order);
        Task<ServiceResponse<bool>> CancelOrder(int id);
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetSortedOrders(string sortName);

    }
}
