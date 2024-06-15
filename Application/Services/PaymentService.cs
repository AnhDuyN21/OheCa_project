using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.PaymentDTOs;
using AutoMapper;
using Domain.Entities;
using MailKit.Search;


namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PaymentViewDTO>> CreatePaymentAsync(CreatePaymentDTO createPaymentDTO)
        {
            ServiceResponse<PaymentViewDTO> reponse = new ServiceResponse<PaymentViewDTO>();
            try
            {
                var paymentEntity = _mapper.Map<Payment>(createPaymentDTO);
                await _unitOfWork.PaymentRepository.AddAsync(paymentEntity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<PaymentViewDTO>(paymentEntity);
                    reponse.Success = true;
                    reponse.Message = "Create new payment successfully";
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

        public async Task<ServiceResponse<PaymentViewDTO>> DeletePaymentAsync(int id)
        {
            var reponse = new ServiceResponse<PaymentViewDTO>();
            try
            {
                var payment = await _unitOfWork.PaymentRepository.GetByIdAsync(id);

                if (payment == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found payment, you are sure input";
                    reponse.Error = "Payment is Null";
                }
                else
                {
                    if (payment.IsDeleted == true)
                    {
                        reponse.Data = _mapper.Map<PaymentViewDTO>(payment);
                        reponse.Success = false;
                        reponse.Message = "Payment is deleted, cant delete again.";
                        reponse.Error = "Is Deleted";
                    }
                    else
                    {
                        _unitOfWork.PaymentRepository.SoftRemove(payment);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            var paymentDetail = await _unitOfWork.PaymentRepository.GetByIdAsync(id);
                            var paymentDTOAfterDeleted = _mapper.Map<PaymentViewDTO>(paymentDetail);
                            reponse.Data = paymentDTOAfterDeleted;
                            reponse.Success = true;
                            reponse.Message = "deleted payment successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update payment fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update payment fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<PaymentViewDTO>> GetPaymentByIdAsync(int paymentId)
        {
            var reponse = new ServiceResponse<PaymentViewDTO>();
            try
            {
                var c = await _unitOfWork.PaymentRepository.GetByIdAsync(paymentId);
                if (c == null && c.IsDeleted != true)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Payment";
                }
                else
                {
                    reponse.Data = _mapper.Map<PaymentViewDTO>(c);
                    reponse.Success = true;
                    reponse.Message = "Payment Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<PaymentViewDTO>>> GetPaymentsAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<PaymentViewDTO>>();
            List<PaymentViewDTO> ListDTO = new List<PaymentViewDTO>();
            try
            {
                var c = await _unitOfWork.PaymentRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Payment";
                }
                else
                {
                    foreach (var cc in c)
                    {
                        if(cc.IsDeleted != true)
                        {
                            var mapper = _mapper.Map<PaymentViewDTO>(cc);
                            ListDTO.Add(mapper);
                        }
                    }
                    reponse.Data = ListDTO;
                    reponse.Success = true;
                    reponse.Message = "Payment Retrieved Successfully";
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

        //Z-A, A-Z , New, Old 
        public async Task<ServiceResponse<IEnumerable<PaymentViewDTO>>> GetSortedPaymentsAsync(string sortName)
        {
            var response = new ServiceResponse<IEnumerable<PaymentViewDTO>>();
            List<PaymentViewDTO> ListDTO = new List<PaymentViewDTO>();
            try
            {
                var payments = await _unitOfWork.PaymentRepository.GetAllAsync();
                if (payments == null || !payments.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any Payment";
                    return response;
                }

                var filteredPayments = payments.Where(x => x.IsDeleted == false);
                if (!filteredPayments.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any Payment";
                    return response;
                }

                IEnumerable<Payment> sortedPayments;
                switch (sortName)
                {
                    case "A-Z":
                        sortedPayments = filteredPayments.OrderBy(x => x.Method);
                        break;
                    case "Z-A":
                        sortedPayments = filteredPayments.OrderByDescending(x => x.Method);
                        break;
                    case "New":
                        sortedPayments = filteredPayments.OrderByDescending(x => x.Id);
                        break;
                    case "Old":
                        sortedPayments = filteredPayments.OrderBy(x => x.Id);
                        break;
                    default:
                        sortedPayments = filteredPayments;
                        break;
                }
                foreach (var cc in payments)
                {
                    if (cc.IsDeleted != true)
                    {
                        var mapper = _mapper.Map<PaymentViewDTO>(cc);
                        ListDTO.Add(mapper);
                    }
                }
                response.Data = ListDTO;
                response.Success = true;
                response.Message = "Payments Retrieved Successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while retrieving payments.";
                response.ErrorMessages = new List<string> { ex.Message };
                if (ex.InnerException != null)
                {
                    response.ErrorMessages.Add(ex.InnerException.Message);
                }
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<PaymentViewDTO>>> searchPaymentByNameAsync(string name)
        {

            var reponse = new ServiceResponse<IEnumerable<PaymentViewDTO>>();
            try
            {
                var c = await _unitOfWork.PaymentRepository.GetAllAsync();
                var p = c.Where(x => x.Method.ToLower().Contains(name.ToLower()) && x.IsDeleted != true).ToList();
                if (p == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Payment";
                }
                else
                {
                    reponse.Data = _mapper.Map<IEnumerable<PaymentViewDTO>>(p);
                    reponse.Success = true;
                    reponse.Message = "Payment Retrieved Successfully";
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

        public async Task<ServiceResponse<PaymentViewDTO>> UpdatePaymentAsync(int id, UpdatePaymentDTO updatePaymentDTO)
        {
            var reponse = new ServiceResponse<PaymentViewDTO>();
            try
            {
                var paymentChecked = await _unitOfWork.PaymentRepository.GetByIdAsync(id);

                if (paymentChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found payment, you are sure input, please checked payment";
                    reponse.Error = "Not found payment";
                }
                else if (paymentChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "payment is deleted, cant update this object";
                    reponse.Error = "This payment detail is deleted";
                }
                else
                {

                    var paymentFofUpdate = _mapper.Map(updatePaymentDTO, paymentChecked);
                    var paymentDTOAfterUpdate = _mapper.Map<PaymentViewDTO>(paymentFofUpdate);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = paymentDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Message = "Update payment detail successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update payment detail fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update payment detail fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }
    }
}
