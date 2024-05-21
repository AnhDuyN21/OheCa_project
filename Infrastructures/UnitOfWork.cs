using Application;
using Application.Repositories;


namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        public UnitOfWork(AppDbContext dbContext, IOrderRepository orderRepository)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
        }
        public IOrderRepository OrderRepository => _orderRepository;
        public Task<int> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
