using Application.ServiceResponse;
using Application.ViewModels.FeedBackDTOs;

namespace Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedbackAsync();
        Task<ServiceResponse<FeedBackViewDTO>> GetFeedbackByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedbackByUserIDAsync(int userID);
        Task<ServiceResponse<FeedBackViewDTO>> CreateFeedbackAsync(FeedBackCreateDTO createDTO);
        Task<ServiceResponse<FeedBackViewDTO>> UpdateFeedbackAsync(int id, FeedBackUpdateDTO updateDTO);
        Task<ServiceResponse<FeedBackViewDTO>> DeleteFeedbackAsync(int id);
    }
}
