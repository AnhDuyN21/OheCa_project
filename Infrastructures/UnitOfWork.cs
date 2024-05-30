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
        public readonly IPaymentRepository _paymentRepository;
        public readonly IShipCompanyRepository _shipCompanyRepository;
        public readonly IShipperRepository _shipperRepository;
        public readonly IAddressToShipRepository _addressToShipRepository;
        public readonly IAddressUserRepository _addressUserRepository;
        public readonly IVoucherRepository _voucherRepository;
        public readonly IVoucherUsageRepository _voucherUsageRepository;

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
            IVoucherUsageRepository voucherUsageRepository)
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

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
