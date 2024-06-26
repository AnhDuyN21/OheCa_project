﻿using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.OrderDTOs;
using AutoMapper;
using Domain.Entities;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<OrderDTO>> CancelOrderAsync(int id)
        {
            var reponse = new ServiceResponse<OrderDTO>();
            try
            {
                var orderChecked = await _unitOfWork.OrderRepository.GetOrderByIDAsync(id);

                if (orderChecked == null )
                {
                    reponse.Success = false;
                    reponse.Message = "Not found order, you are sure input";
                    reponse.Error = "Not found order";
                }
                else if (orderChecked.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Message = "Order are deleted, can not cancel order.";
                }
                else if (orderChecked.IsConfirm == 1)
                {
                    reponse.Success = false;
                    reponse.Message = "Order is confirm, can not cancel order.";
                }
                else
                {
                    //trang thai đơn hàng chưa active thì cho phép update
                    if (orderChecked.Status == 1)
                    {
                        //var orderFofUpdate = _mapper.Map(order, orderChecked);
                        orderChecked.Status = 0;
                        var orderFofUpdate = _mapper.Map<OrderDTO>(orderChecked);
                        var orderDTOAfterUpdate = _mapper.Map<OrderDTO>(orderFofUpdate);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Data = orderDTOAfterUpdate;
                            reponse.Success = true;
                            reponse.Message = "Update order successfully";
                        }
                        else
                        {
                            reponse.Data = orderDTOAfterUpdate;
                            reponse.Success = false;
                            reponse.Message = "Update order fail!";
                        }
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update order fail, order is deleted, cannot update";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update order fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<OrderDTO>> CreateOrderAsync(CreateOrderDTO order)
        {
            var reponse = new ServiceResponse<OrderDTO>();

            try
            {
                var orderentity = _mapper.Map<Order>(order);
                
                    await _unitOfWork.OrderRepository.AddAsync(orderentity);
                    
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = _mapper.Map<OrderDTO>(orderentity);
                        reponse.Success = true;
                        reponse.Message = "Create new order successfully";
                        reponse.Error = string.Empty;
                        return reponse;
                    }
                }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;

        }

        public async Task<ServiceResponse<OrderDTO>> GetOrderByIdAsync(int orderId)
        {
            var _response = new ServiceResponse<OrderDTO>();
            try
            {
                var c = await _unitOfWork.OrderRepository.GetOrderByIDAsync(orderId);
                if (c == null)
                {
                    _response.Success = false;
                    _response.Message = "Don't Have Any Order ";
                }
                else
                {
                    _response.Data = _mapper.Map<OrderDTO>(c);
                    _response.Success = true;
                    _response.Message = "Order Retrieved Successfully";
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;

        }

        public async Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrderByUserIDAsync(int userId)
        {
            var reponse = new ServiceResponse<IEnumerable<OrderDTO>>();
            List<OrderDTO> OrderDTOs = new List<OrderDTO>();
            try
            {
                List<Order> orders =  (await _unitOfWork.OrderRepository.GetAllOrderByUserIdAsync(userId)).ToList();
                foreach (var order in orders)
                {
                    OrderDTOs.Add(_mapper.Map<OrderDTO>(order));
                }
                if (OrderDTOs.Count > 0)
                {
                    reponse.Data = OrderDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {OrderDTOs.Count} order.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {OrderDTOs.Count} order.";
                    reponse.Error = "Not have a order";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Error = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }

        public async Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrdersAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<OrderDTO>>();
            List<OrderDTO> OrderDTOs = new List<OrderDTO>();
            try
            {
                var orders = await _unitOfWork.OrderRepository.GetAllAsync();
                foreach (var order in orders)
                {
                    OrderDTOs.Add(_mapper.Map<OrderDTO>(order));
                }
                if (OrderDTOs.Count > 0)
                {
                    reponse.Data = OrderDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {OrderDTOs.Count} order.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {OrderDTOs.Count} order.";
                    reponse.Error = "Not have a order";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Error = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

        }

        public Task<ServiceResponse<IEnumerable<OrderDTO>>> GetSortedOrdersAsync(string sortName)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<OrderDTO>> UpdateOrderAsync(int id, UpdateOrderDTO order)
        {
            var reponse = new ServiceResponse<OrderDTO>();
            try
            {
                var orderChecked = await _unitOfWork.OrderRepository.GetOrderByIDAsync(id);

                if (orderChecked == null && orderChecked.IsDeleted == false)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found order, you are sure input";
                    reponse.Error = "Not found order";
                }
                else
                {
                    //trang thai đơn hàng chưa active thì cho phép update
                    if (orderChecked.Status == 1)
                    {
                        var orderFofUpdate = _mapper.Map(order, orderChecked);
                        var orderDTOAfterUpdate = _mapper.Map<OrderDTO>(orderFofUpdate);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Data = orderDTOAfterUpdate;
                            reponse.Success = true;
                            reponse.Message = "Update order successfully";
                        }
                        else
                        {
                            reponse.Data = orderDTOAfterUpdate;
                            reponse.Success = false;
                            reponse.Message = "Update order fail!";
                        }
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update order fail, order is deleted, cannot update";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update order fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;

        }
    }
}
