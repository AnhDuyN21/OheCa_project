using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<IEnumerable<Order>> GetAllOrderByUserIdAsync(int userID);
        public Task<IEnumerable<Order>> GetAllByStatusAsync(int status);
        public Task<Order> GetOrderByIDAsync(int id);
        //public Task AddAsync(Order order);
        //public void Update(Order order);
        //public void Delete(Order order);
    }
}
