using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.FeedbackDTOs;
using Application.ViewModels.OrderDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FeedbackService : IFeedbackService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<FeedbackDTO>>> GetFeedbacksAsync(int productId)
        {


            var reponse = new ServiceResponse<IEnumerable<FeedbackDTO>>();
            List<FeedbackDTO> feedbackDTOs = new List<FeedbackDTO>();

            try
            {
                var feedbacks = await _unitOfWork.FeedBackRepository.GetAllFeedbacksByProductAsync(productId);
                foreach (var feedback in feedbackDTOs)
                {
                    feedbackDTOs.Add(_mapper.Map<FeedbackDTO>(feedback));
                }

                if(feedbackDTOs.Count > 0)
                {
                    reponse.Data = feedbackDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {feedbackDTOs.Count} feedbacks.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {feedbackDTOs.Count} feedbacks.";
                    reponse.Error = "Not have a feedbacks";
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
    }
}
