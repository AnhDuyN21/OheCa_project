using Application;
using Application.Repositories;


namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public UnitOfWork(AppDbContext dbContext, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public IOrderRepository OrderRepository => _orderRepository;
        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;
        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
