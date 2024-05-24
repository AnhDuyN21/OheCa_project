using Application;
using Application.Repositories;


namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
<<<<<<< HEAD
        private readonly IProductRepository _productRepository;
        public UnitOfWork(AppDbContext dbContext, IOrderRepository orderRepository, IProductRepository productRepository)
=======
        private readonly IOrderDetailRepository _orderDetailRepository;
        public readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext dbContext,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUserRepository userRepository)
>>>>>>> 129aedc82e6d237017c2fe12af7bc8a7b6acc561
        {
            _dbContext = dbContext;

            _orderRepository = orderRepository;
<<<<<<< HEAD
            _productRepository = productRepository;

        }
        public IOrderRepository OrderRepository => _orderRepository;

        public IProductRepository ProductRepository => _productRepository;
        public Task<int> SaveChangeAsync()
=======

            _orderDetailRepository = orderDetailRepository;

            _userRepository = userRepository;
        }
        public IOrderRepository OrderRepository => _orderRepository;
        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;
        public IUserRepository UserRepository => _userRepository;
        public async Task<int> SaveChangeAsync()
>>>>>>> 129aedc82e6d237017c2fe12af7bc8a7b6acc561
        {
            return await _dbContext.SaveChangesAsync();
        }


    }
}
