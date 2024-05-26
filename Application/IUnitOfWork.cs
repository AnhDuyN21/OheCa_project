using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }

        public IUserRepository UserRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IImageRepository ImageRepository { get; }

        public IProductMaterialRepository ProductMaterialRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
