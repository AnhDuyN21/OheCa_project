using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public OrderRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Order>> GetAllByStatusAsync(int status)
        {
            var Orders = await _dbContext.Orders.Where(o => o.Status == status).ToListAsync();
            if (Orders.Any() == false)
            {
                throw new Exception("UserID haven't Order");
            }
            return Orders;
        }

        public async Task<IEnumerable<Order>> GetAllOrderByUserIdAsync(int userID)
        {
            var Orders = await _dbContext.Orders.Where(o => o.UserId == userID).ToListAsync();
            if (Orders.Any() == false)
            {
                throw new Exception("UserID haven't Order");
            }
            return Orders;
        }


        public async Task<Order> GetOrderByIDAsync(int id)
        {
            var Order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (Order is null)
            {
                throw new Exception("UserID haven't Order");
            }
            return Order;
        }
    }

}
