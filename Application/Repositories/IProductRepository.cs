using Application.ViewModels.ProductDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<Product> GetProductByIDAsync(int id);

        public Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);

    }
}
