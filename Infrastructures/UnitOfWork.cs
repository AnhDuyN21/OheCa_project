using Application;
using Application.Repositories;
using Infrastructures.Repositories;


namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IProductMaterialRepository _productMaterialRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        
        public UnitOfWork(AppDbContext dbContext, IOrderRepository orderRepository, IProductRepository productRepository,IOrderDetailRepository orderDetailRepository,
            IUserRepository userRepository, IImageRepository imageRepository, IProductMaterialRepository productMaterialRepository, IFeedbackRepository feedbackRepository)
        {
            _dbContext = dbContext;

            _orderRepository = orderRepository;

            _orderDetailRepository = orderDetailRepository;

            _userRepository = userRepository;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _productMaterialRepository = productMaterialRepository;
            _feedbackRepository = feedbackRepository;

        }
        public IOrderRepository OrderRepository => _orderRepository;
        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;
        public IUserRepository UserRepository => _userRepository;

        public IProductRepository ProductRepository => _productRepository;

        public IImageRepository ImageRepository => _imageRepository;

        public IProductMaterialRepository ProductMaterialRepository => _productMaterialRepository;

        public IFeedbackRepository FeedbackRepository => _feedbackRepository;
        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


    }
}
