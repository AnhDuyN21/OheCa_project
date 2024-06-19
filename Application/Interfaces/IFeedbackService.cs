using Application.ServiceResponse;
using Application.ViewModels.FeedBackDTOs;


namespace Application.Interfaces
{
    public interface IFeedBackService
    {
        Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedBackAsync();
        Task<ServiceResponse<FeedBackViewDTO>> GetFeedBackByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedBackByUserIDAsync(int userID);
        Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedBackInProduct(int pID);
        Task<ServiceResponse<FeedBackViewDTO>> CreateAFeedBackAsync(FeedBackCreateDTO createDTO);
        Task<ServiceResponse<FeedBackViewDTO>> UpdateFeedBackAsync(int id, FeedBackUpdateDTO updateDTO);
        Task<ServiceResponse<FeedBackViewDTO>> DeleteFeedBackAsync(int id);
    }
}
