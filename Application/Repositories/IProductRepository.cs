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

        public Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId, int? pageIndex = null, int? pageSize = null);

        public Task<IEnumerable<Product>> GetProductAsync(int? pageIndex = null, int? pageSize = null);

        public Task<IEnumerable<Product>> GetProductByDiscount(int? pageIndex = null, int? pageSize = null);

        public Task<IEnumerable<Product>> GetProductByBrand(int brandId, int? pageIndex = null, int? pageSize = null);

        public Task<IEnumerable<Product>> GetProductByFeedback(int rate, int? pageIndex = null, int? pageSize = null);

        public Task<IEnumerable<Product>> GetProductByChildCategory(int childcategoryId, int? pageIndex = null, int? pageSize = null);






    }
}
