using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public FeedbackRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksByProductAsync(int productId)
        {
            var feedbacks = await _dbContext.Feedbacks.Where(f => f.ProductId == productId).ToListAsync();
            if(feedbacks != null)
            {
                return feedbacks;
            }
            else
            {
                throw new Exception("Don't find Feedback By ProductId");
            }
        }
    }
}
