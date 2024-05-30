using Application.ServiceResponse;
using Application.ViewModels.FeedbackDTOs;
using Application.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<ServiceResponse<IEnumerable<FeedbackDTO>>> GetFeedbacksAsync(int productId);
    }
}
