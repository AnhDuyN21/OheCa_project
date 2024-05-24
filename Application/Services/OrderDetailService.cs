using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.OrderDTOs;
using AutoMapper;
using Azure;
using Domain.Entities;

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

        public Task<ServiceResponse<IEnumerable<OrderDetailDTO>>> GetOrderDetailByOrderIdsAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<OrderDetailDTO>>> GetOrderDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<OrderDetailDTO>> UpdateOrderDetailAsync(int id, UpdateOrderDetailDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
