using Domain.Entities;

namespace Application.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<IEnumerable<Order>> GetAllOrderByUserIdAsync(int userID);
        public Task<IEnumerable<Order>> GetAllByStatusAsync(int status);
        public Task<Order> GetOrderByIDAsync(int id);
        Task<bool> ChangeStatusOfPayment(int orderId);
        //public Task AddAsync(Order order);
        //public void Update(Order order);
        //public void Delete(Order order);
    }
}
