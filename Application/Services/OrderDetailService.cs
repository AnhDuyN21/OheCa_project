using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.UserDTO;
using AutoMapper;
using Azure;
using Domain.Entities;
using MailKit.Search;
using static Google.Apis.Requests.BatchRequest;

namespace Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<OrderDetailDTO>> CreateOrderDetailAsync(CreateOrderDetailDTO orderDetail)
        {
            ServiceResponse<OrderDetailDTO> reponse = new ServiceResponse<OrderDetailDTO>();
            try
            {
                var orderEntity = _mapper.Map<OrderDetail>(orderDetail);
                await _unitOfWork.OrderDetailRepository.AddAsync(orderEntity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<OrderDetailDTO>(orderEntity);
                    reponse.Success = true;
                    reponse.Message = "Create new OrderDetail successfully";
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Message = ex.Message;
                reponse.ErrorMessages = new List<string> { ex.InnerException.ToString() };
            }
            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<OrderDetailViewDTO>>> DeletedOrderDetailRange(int orderid)
        {
            var reponse = new ServiceResponse<IEnumerable<OrderDetailViewDTO>>();
            try
            {
                var orderDetails = await _unitOfWork.OrderDetailRepository.GetAllAsync();
                var filterOrderDetails = orderDetails.Where(x => x.OrderId == orderid && x.IsDeleted == false).ToList();

                if (filterOrderDetails == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found orderdetail, you are sure input";
                    reponse.Error = "Not found orderdetail, orderdeil into order is null";
                }
                else
                {
                         _unitOfWork.OrderDetailRepository.SoftRemoveRange(filterOrderDetails);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            var orderDetail = await _unitOfWork.OrderDetailRepository.GetAllAsync();
                            var filterOrderDetailAfterDeleted = orderDetail.Where(x => x.OrderId == orderid).ToList();
                            var orderDTOAfterUpdate = _mapper.Map<IEnumerable<OrderDetailViewDTO>>(filterOrderDetailAfterDeleted);
                            reponse.Data = orderDTOAfterUpdate;
                            reponse.Success = true;
                            reponse.Message = "deleted order detail successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update order detail fail!";
                        }
                    
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update order detail fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<OrderDetailDTO>> GetOrderDetailByIdAsync(int orderdetailId)
        {
            var reponse = new ServiceResponse<OrderDetailDTO>();
            try
            {
                var c = await _unitOfWork.OrderDetailRepository.GetByIdAsync(orderdetailId);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Order Detail";
                    return reponse;
                }
                else
                {
                    reponse.Data = _mapper.Map<OrderDetailDTO>(c);
                    reponse.Success = true;
                    reponse.Message = "Order Detail Retrieved Successfully";
                }
            } catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Message = ex.Message;
                reponse.ErrorMessages = new List<string>{ex.InnerException.ToString()};
            }
            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<OrderDetailDTO>>> GetOrderDetailByOrderIdsAsync(int orderId)
        {
            ServiceResponse<IEnumerable<OrderDetailDTO>> reponse = new ServiceResponse<IEnumerable<OrderDetailDTO>>();
            try
            {
                var c = await _unitOfWork.OrderDetailRepository.GetAllAsync();
                
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = $"Don't Have Any Order Detail in system.";
                }
                else
                {
                    var filterOrderByOId = c.Where(x => x.OrderId == orderId).ToList();
                    if (filterOrderByOId == null || filterOrderByOId.Count <= 0)
                    {
                        reponse.Success = false;
                        reponse.Message = $"Don't Have Any Order Detail In Order Have Id = {orderId}";
                    }
                    else
                    {
                        reponse.Data = _mapper.Map<IEnumerable<OrderDetailDTO>>(filterOrderByOId);
                        reponse.Success = true;
                        reponse.Message = "Order Detail Retrieved Successfully";
                    }
                }
            }
            catch(Exception e)
            {
                reponse.Success = false;
                reponse.Error = e.Message;
                reponse.ErrorMessages = new List<string> { e.InnerException.ToString() };
            }
            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<OrderDetailViewDTO>>> GetOrderDetailsAsync()
        {
            ServiceResponse<IEnumerable<OrderDetailViewDTO>> reponse = new ServiceResponse<IEnumerable<OrderDetailViewDTO>>();
            try
            {
                var c = await _unitOfWork.OrderDetailRepository.GetAllAsync();

                if (c == null || c.Count <= 0)
                {
                    reponse.Success = false;
                    reponse.Message = $"Don't Have Any Order Detail";
                    return reponse;
                }
                else
                {
                    reponse.Data = _mapper.Map<IEnumerable<OrderDetailViewDTO>>(c);
                    reponse.Success = true;
                    reponse.Message = "Order Detail Retrieved Successfully";
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Error = e.Message;
                reponse.ErrorMessages = new List<string> { e.InnerException.ToString() };
            }
            return reponse;
        }

        public async Task<ServiceResponse<OrderDetailDTO>> UpdateOrderDetailAsync(int id, UpdateOrderDetailDTO orderdetail)
        {
            var reponse = new ServiceResponse<OrderDetailDTO>();
            try
            {
                var orderDetailChecked = await _unitOfWork.OrderDetailRepository.GetByIdAsync(id);

                if (orderDetailChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found order, you are sure input, please checked orderdetailid";
                    reponse.Error = "Not found order";
                }
                else if (orderDetailChecked.IsDeleted == true)
                {
                    
                        reponse.Success = false;
                        reponse.Message = "Order Detail is deleted, cant update this object";
                        reponse.Error = "This order detail is deleted";
                }
                else
                {
                   
                        var orderDetailFofUpdate = _mapper.Map(orderdetail, orderDetailChecked);
                        var orderDetailDTOAfterUpdate = _mapper.Map<OrderDetailDTO>(orderDetailFofUpdate);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Data = orderDetailDTOAfterUpdate;
                            reponse.Success = true;
                            reponse.Message = "Update order detail successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update order detail fail!";
                        }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update order detail fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }
        
        public async Task<ServiceResponse<List<OrderDetailDTO>>> GetOrderDetailByOrderId (int id)
        {
            var reponse = new ServiceResponse<List<OrderDetailDTO>>();
            try
            {
                var orderDetailList = await _unitOfWork.OrderDetailRepository.GetOrderDetailByOrderID(id);
                List<OrderDetailDTO> result = new List<OrderDetailDTO>();
                foreach (var orderDetail in orderDetailList)
                {
                    result.Add(_mapper.Map<OrderDetailDTO>(orderDetail));
                }
                reponse.Success = true;
                reponse.Message = "Get order detail by order id success";
                reponse.Data = result;
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Error";
                reponse.ErrorMessages = new List<string> { e.Message };
            }
            return reponse;
        }
    }
}
