using Application;
using Application.Repositories;


namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public UnitOfWork(AppDbContext dbContext, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _productRepository = productRepository;

        }
        public IOrderRepository OrderRepository => _orderRepository;

        public IProductRepository ProductRepository => _productRepository;
        public Task<int> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }


    }
}
