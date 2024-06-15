using Application;
using Application.Repositories;


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
        private readonly IFeedBackRepository _feedBackRepository;

        public UnitOfWork(AppDbContext dbContext,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUserRepository userRepository,
            IPaymentRepository paymentRepository,
            IShipCompanyRepository shipCompanyRepository,
            IShipperRepository shipperRepository,
            IAddressToShipRepository addressToShipRepository,
            IAddressUserRepository addressUserRepository,
            IVoucherRepository voucherRepository,
            IVoucherUsageRepository voucherUsageRepository,
            IFeedBackRepository feedBackRepository)
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
            _feedBackRepository = feedBackRepository;
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
        public IFeedBackRepository FeedBackRepository => _feedBackRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
