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

        public Task<IEnumerable<Product>> GetProductAsync();

        public Task<IEnumerable<Product>> GetProductByDiscount();

        public Task<IEnumerable<Product>> GetProductByBrand(int brandId);

        public Task<IEnumerable<Product>> GetProductByFeedback(int rate);

        public Task<IEnumerable<Product>> GetProductByChildCategory(int childcategoryId);

        


        

    }
}
