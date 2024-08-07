﻿using Application.ServiceResponse;
using Application.ViewModels.OrderDTOs;
using Domain.Entities;
using Org.BouncyCastle.Utilities;
using System.Linq.Expressions;
using System.Security.Claims;


namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrdersAsync();
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrderCompleteAsync();
        Task<ServiceResponse<TotalOrderDTO>> GetTotalOrderAsync();
        Task<ServiceResponse<OrderDTO>> GetOrderByIdAsync(int orderId);
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrderByUserIDAsync(int userId);
        Task<ServiceResponse<OrderDTO>> CreateOrderAsync(CreateOrderDTO order);
        Task<ServiceResponse<OrderDTO>> UpdateOrderAsync(int id,UpdateOrderDTO order);
        Task<ServiceResponse<OrderDTO>> CancelOrderAsync(int id);
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetSortedOrdersAsync(string sortName);
        Task<ServiceResponse<OrderDTO>> CheckoutAsync(CheckoutDTO order);
        Task<ServiceResponse<string>> ConfirmOrder(int id);
        Task<ServiceResponse<string>> CancelOrder(int id);
        Task<ServiceResponse<string>> ReceivedOrder(int id);
        Task<ServiceResponse<bool>> ChangeStatusOfPaymentAsync(int orderId);

    }
}
