using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; }

        public IOrderDetailRepository OrderDetailRepository { get; }

        public IUserRepository UserRepository { get; }

        public IPaymentRepository PaymentRepository { get; }

        public IShipCompanyRepository ShipCompanyRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
