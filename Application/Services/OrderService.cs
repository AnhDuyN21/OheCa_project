using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.UserDTO;
using AutoMapper;
using Azure;
using Domain.Entities;
using Domain.Enum;
using MailKit.Search;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IProductService productService, IOrderDetailService orderDetailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }

        public async Task<ServiceResponse<string>> CancelOrder(int id)
        {
            var reponse = new ServiceResponse<string>();
            try
            {
                var orderChecked = await _unitOfWork.OrderRepository.GetOrderByIDAsync(id);

                if (orderChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found order, you are sure input";
                    reponse.Error = "Not found order";
                }
                else
                {
                    if (orderChecked.IsConfirm == 0)
                    {
                        orderChecked.IsConfirm = 2;
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Success = true;
                            reponse.Message = "Confirm order successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Confirm order fail!";
                        }
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Cancel order fail, order is confirmed, cannot cancel";
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
                    if (orderChecked.Status == 0)
                    {
                        orderChecked.Status = 2;
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
                        reponse.Message = "Update order fail!, Because order is processing or completed";
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

        public async Task<ServiceResponse<OrderDTO>> CheckoutAsync(CheckoutDTO order)
        {
            var response = new ServiceResponse<OrderDTO>();

            if (order.Carts == null || !order.Carts.Any() || order.Carts.Any(c => c.ProductId == null || c.Quantity == null || c.Quantity <= 0))
            {
                response.Success = false;
                response.ErrorMessages = new List<string> { "Must have at least one valid product for checkout." };
                return response;
            }

            try
            {
                var orderEntity = _mapper.Map<Order>(order);
                await _unitOfWork.OrderRepository.AddAsync(orderEntity);
                if( await _unitOfWork.SaveChangeAsync() > 0)
                {
                    foreach (var cart in order.Carts)
                    {
                        var product = await _unitOfWork.ProductRepository.GetProductByIDAsync((int)cart.ProductId);
                        var orderDetail = new OrderDetail
                        {
                            OrderId = orderEntity.Id,
                            ProductId = cart.ProductId.Value,
                            Quantity = cart.Quantity.Value,
                            Price = product.PriceSold.Value
                        };
                        var updateQuanity = await _productService.UpdateQuanityAsync((int)cart.ProductId, (int)cart.Quantity);
                        if(updateQuanity.Success == false)
                        {
                            response.Success = false;
                            response.Message = updateQuanity.Message + updateQuanity.Error;
                            return response;
                        }
                        await _unitOfWork.OrderDetailRepository.AddAsync(orderDetail);
                    }

                    var shipper = await _unitOfWork.ShipperRepository.GetAllAsync();

                    orderEntity.ShipperId = shipper.FirstOrDefault().Id;
                    orderEntity.ShipDate = DateTime.Now.AddDays(1);
                    orderEntity.ReceiveDate = DateTime.Now.AddDays(5);
                    orderEntity.IsConfirm = 0;
                    orderEntity.Status = (int)OrderStatusEnum.Pending;
                    orderEntity.StatusOfPayment = 0;
                    orderEntity.CreationDate = DateTime.Now.AddHours(7);
                    _unitOfWork.OrderRepository.Update(orderEntity);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        response.Data = _mapper.Map<OrderDTO>(orderEntity);
                        response.Success = true;
                        response.Message = "Create new order successfully";
                        return response;
                    }
                }
                    
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return response;
            }

            response.Success = false;
            response.Message = "Failed to create new order.";
            return response;
        }

        public async Task<ServiceResponse<string>> ConfirmOrder(int id)
        {
            var reponse = new ServiceResponse<string>();
            try
            {
                var orderChecked = await _unitOfWork.OrderRepository.GetOrderByIDAsync(id);

                if (orderChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found order, you are sure input";
                    reponse.Error = "Not found order";
                }
                else
                {
                    if (orderChecked.IsConfirm == 0)
                    {
                        orderChecked.IsConfirm = 1;
                        orderChecked.Status = (int)Domain.Enum.OrderStatusEnum.Processing;
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Success = true;
                            reponse.Message = "Confirm order successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Confirm order fail!";
                        }
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update order fail, order is confirmed, cannot update";
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
                var orderEntity = _mapper.Map<Order>(order);
                        await _unitOfWork.OrderRepository.AddAsync(orderEntity);
                    
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = _mapper.Map<OrderDTO>(orderEntity);
                        reponse.Success = true;
                        reponse.Message = "Create new order successfully";
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
                var order = await _unitOfWork.OrderRepository.GetOrderByIDAsync(orderId);

                if (order == null)
                {
                    _response.Success = false;
                    _response.Message = "Don't Have Any Order";
                    return _response;
                }

                var orderDetailResponse = await _orderDetailService.GetOrderDetailByOrderId(orderId);
                if (!orderDetailResponse.Success || orderDetailResponse.Data == null || !orderDetailResponse.Data.Any())
                {
                    _response.Success = false;
                    _response.Message = "Order details not found.";
                    return _response;
                }

                var orderDto = _mapper.Map<OrderDTO>(order);

                var productId = orderDetailResponse.Data.FirstOrDefault()?.ProductId;
                if (productId.HasValue)
                {
                    orderDto.ImageLink =  _productService.GetProductByIdAsync(productId.Value).Result.Data.Images.FirstOrDefault().ImageLink.ToString();
                }

                _response.Data = orderDto;
                _response.Success = true;
                _response.Message = "Order Retrieved Successfully";
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
                    var orderDetailResponse = await _orderDetailService.GetOrderDetailByOrderId(order.Id);
                    var orderDto = _mapper.Map<OrderDTO>(order);

                    var productId = orderDetailResponse.Data.FirstOrDefault()?.ProductId;
                    if (productId.HasValue)
                    {
                        orderDto.ImageLink = _productService.GetProductByIdAsync(productId.Value).Result.Data.Images.FirstOrDefault().ImageLink.ToString();
                    }
                    OrderDTOs.Add(orderDto);

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

        public async Task<ServiceResponse<IEnumerable<OrderDTO>>> GetOrderCompleteAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<OrderDTO>>();
            List<OrderDTO> OrderDTOs = new List<OrderDTO>();
            try
            {
                var orders = await _unitOfWork.OrderRepository.GetAllAsync();
                foreach (var order in orders)
                {
                    if(order.Status == 3)
                    {
                        var orderDetailResponse = await _orderDetailService.GetOrderDetailByOrderId(order.Id);
                        var orderDto = _mapper.Map<OrderDTO>(order);

                        var productId = orderDetailResponse.Data.FirstOrDefault()?.ProductId;
                        if (productId.HasValue)
                        {
                            orderDto.ImageLink = _productService.GetProductByIdAsync(productId.Value).Result.Data.Images.FirstOrDefault().ImageLink.ToString();
                        }
                        OrderDTOs.Add(orderDto);
                    }
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
                    var orderDetailResponse = await _orderDetailService.GetOrderDetailByOrderId(order.Id);
                    var orderDto = _mapper.Map<OrderDTO>(order);

                    var productId = orderDetailResponse.Data.FirstOrDefault()?.ProductId;
                    if (productId.HasValue)
                    {
                        orderDto.ImageLink = _productService.GetProductByIdAsync(productId.Value).Result.Data.Images.FirstOrDefault().ImageLink.ToString();
                    }
                    OrderDTOs.Add(orderDto);

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

        public async Task<ServiceResponse<TotalOrderDTO>> GetTotalOrderAsync()
        {
            var reponse = new ServiceResponse<TotalOrderDTO>();
            try
            {
                var orders = await _unitOfWork.OrderRepository.GetAllAsync();
                
                if (orders.Count > 0)
                {
                    var orderView = new TotalOrderDTO();
                    orderView.totalOrder = orders.Count;
                    orderView.totalOrderFailed = orders.Where(x => x.Status == (int)Domain.Enum.OrderStatusEnum.Cancelled).Count();
                    orderView.totalRevenue = (decimal)orders.Where(x => x.TotalPrice.HasValue).Sum(x => x.TotalPrice.Value);
                    orderView.totalOrderIsShipping = orders.Where(x => x.Status == (int)Domain.Enum.OrderStatusEnum.Processing).Count();
                    orderView.totalOrderCompleted = orders.Where(x => x.Status == (int)Domain.Enum.OrderStatusEnum.Completed).Count(); 
                    reponse.Data = orderView;
                    reponse.Success = true;
                    reponse.Message = $"Successfully.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Fail.";
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

        public async Task<ServiceResponse<string>> ReceivedOrder(int id)
        {
            var reponse = new ServiceResponse<string>();
            try
            {
                var orderChecked = await _unitOfWork.OrderRepository.GetOrderByIDAsync(id);

                if (orderChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found order, you are sure input";
                    reponse.Error = "Not found order";
                }
                else if (orderChecked.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Message = "Order are deleted, can not received order.";
                }
                else if (orderChecked.IsConfirm == 1)
                {
                    if (orderChecked.Status == 0 || orderChecked.Status == 1)
                    {
                        orderChecked.Status = 3;
                        if(orderChecked.StatusOfPayment == 0)
                        {
                            orderChecked.StatusOfPayment = 1;
                            var orderFofUpdate = _mapper.Map<OrderDTO>(orderChecked);
                            var orderDTOAfterUpdate = _mapper.Map<OrderDTO>(orderFofUpdate);
                            if (await _unitOfWork.SaveChangeAsync() > 0)
                            {
                                reponse.Success = true;
                                reponse.Message = "received order successfully";
                            }
                            else
                            {
                                reponse.Success = false;
                                reponse.Message = "received order fail!";
                            }
                        }
                        else
                        {
                            reponse.Success = true;
                            reponse.Message = "received order succesful!";
                        }
                        
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "received order fail, order is unpaid or not yet delivered , cannot received";
                    }
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = "received order fail";
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

        public async Task<ServiceResponse<OrderDTO>> UpdateOrderAsync(int id, UpdateOrderDTO order)
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
                else
                {
                    if (orderChecked.Status < 2)
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
                        reponse.Message = "Update order fail, order is cancel or complete, cannot update";
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
        public async Task<ServiceResponse<bool>> ChangeStatusOfPaymentAsync(int orderId)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId);
                if(order == null)
                {
                    response.Success = false;
                    response.Message = "orderId not found!";
                    return response;
                }
                if(order.StatusOfPayment == 1)
                {
                    response.Success = false;
                    response.Message = $"Status of payment in this orderID( {order.Id} ) already equal 1";
                    return response;
                }
                await _unitOfWork.OrderRepository.ChangeStatusOfPayment(orderId);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess)
                {
                    response.Success = true;
                    response.Message = "change successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error.";
                }
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = "Update order fail!, exception";
                response.ErrorMessages = new List<string> { e.Message };
            }
            return response;
        }
    }
}
