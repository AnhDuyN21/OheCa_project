using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; }
<<<<<<< HEAD
        public IProductRepository ProductRepository { get; }
=======

        public IOrderDetailRepository OrderDetailRepository { get; }

        public IUserRepository UserRepository { get; }

>>>>>>> 129aedc82e6d237017c2fe12af7bc8a7b6acc561
        public Task<int> SaveChangeAsync();
    }
}
