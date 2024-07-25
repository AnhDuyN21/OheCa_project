using Application.ServiceResponse;
using Application.ViewModels.OrderDTOs;
using Domain.Entities;
using System.Linq.Expressions;
using System.Security.Claims;


namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrdersAsync();
        Task<ServiceResponse<OrderDTO>> GetOrderByIdAsync(int orderId);
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrderByUserIDAsync(int userId);
        Task<ServiceResponse<OrderDTO>> CreateOrderAsync(CreateOrderDTO order);
        Task<ServiceResponse<OrderDTO>> UpdateOrderAsync(int id,UpdateOrderDTO order);
        Task<ServiceResponse<OrderDTO>> CancelOrderAsync(int id);
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetSortedOrdersAsync(string sortName);
        Task<ServiceResponse<OrderDTO>> CheckoutAsync(CheckoutDTO order);
        Task<ServiceResponse<string>> ConfirmOrder(int id);

    }
}
