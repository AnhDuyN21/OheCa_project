using Application;
using Application.Repositories;


namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext dbContext,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUserRepository userRepository)
        private readonly IProductRepository _productRepository;
        public UnitOfWork(AppDbContext dbContext, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _dbContext = dbContext;

            _orderRepository = orderRepository;

            _orderDetailRepository = orderDetailRepository;

            _userRepository = userRepository;
            _productRepository = productRepository;

        }
        public IOrderRepository OrderRepository => _orderRepository;
        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;
        public IUserRepository UserRepository => _userRepository;
        public async Task<int> SaveChangeAsync()

        public IProductRepository ProductRepository => _productRepository;
        public Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


    }
}
