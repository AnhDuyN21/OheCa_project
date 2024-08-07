﻿using Application;
using Application.Repositories;
using Infrastructures.Repositories;


namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IShipCompanyRepository _shipCompanyRepository;
        private readonly IShipperRepository _shipperRepository;
        private readonly IAddressToShipRepository _addressToShipRepository;
        private readonly IAddressUserRepository _addressUserRepository;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IVoucherUsageRepository _voucherUsageRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        

        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IProductMaterialRepository _productMaterialRepository;
        private readonly IFeedbackRepository _feedbackRepository;

      
        
        public UnitOfWork(AppDbContext dbContext, IOrderRepository orderRepository, IProductRepository productRepository,IOrderDetailRepository orderDetailRepository,
            IUserRepository userRepository, IImageRepository imageRepository, IProductMaterialRepository productMaterialRepository,
            IPaymentRepository paymentRepository, IShipCompanyRepository shipCompanyRepository, IShipperRepository shipperRepository, IAddressToShipRepository addressToShipRepository,
            IAddressUserRepository addressUserRepository, IVoucherRepository voucherRepository,
            IVoucherUsageRepository _voucherUsageRepository, IVoucherUsageRepository voucherUsageRepository,
            IPostRepository postRepository, ICommentRepository commentRepository, IFeedbackRepository feedbackRepository
            )
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
            _shipCompanyRepository = shipCompanyRepository;
            _shipperRepository = shipperRepository;
            _addressToShipRepository = addressToShipRepository;
            _addressUserRepository = addressUserRepository;
            _voucherRepository = voucherRepository;
            _voucherUsageRepository = voucherUsageRepository;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _productMaterialRepository = productMaterialRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _feedbackRepository = feedbackRepository;
        }
        public IOrderRepository OrderRepository => _orderRepository;
        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;
        public IUserRepository UserRepository => _userRepository;
        public IPaymentRepository PaymentRepository => _paymentRepository;
        public IShipCompanyRepository ShipCompanyRepository => _shipCompanyRepository;
        public IShipperRepository ShipperRepository => _shipperRepository;
        public IAddressToShipRepository AddressToShipRepository => _addressToShipRepository;
        public IAddressUserRepository AddressUserRepository => _addressUserRepository;
        public IVoucherRepository VoucherRepository => _voucherRepository;
        public IVoucherUsageRepository VoucherUsageRepository => _voucherUsageRepository;
        
        public IProductRepository ProductRepository => _productRepository;

        public IImageRepository ImageRepository => _imageRepository;

        public IProductMaterialRepository ProductMaterialRepository => _productMaterialRepository;
        public IPostRepository PostRepository => _postRepository;
        public ICommentRepository CommentRepository => _commentRepository;

        public IFeedbackRepository FeedbackRepository => _feedbackRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


    }
}
