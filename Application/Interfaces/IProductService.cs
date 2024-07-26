using Application.ServiceResponse;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.ProductDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductsAsync(int? pageIndex = null, int? pageSize = null);

        
            Task<ServiceResponse<IEnumerable<ProductDetailDTO>>> GetProductsForAdminAsync(int? brandId = null, int? categoryId = null);

        Task<ServiceResponse<ProductDetailDTO>> GetProductByIdAsync(int productId);
        Task<ServiceResponse<IEnumerable<ProductDetailDTO>>> GetProductByCategoryAsync(int categoryid, int? pageIndex, int? pageSize);

        Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductByDiscountAsync(int? pageIndex = null, int? pageSize = null);
        Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductByBrand(int brandId, int? pageIndex, int? pageSize);
        Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductByFeedback(int rate, int? pageIndex = null, int? pageSize = null);
        Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductByChildCategory(int childcategoryId, int? pageIndex = null, int? pageSize = null);


        Task<ServiceResponse<ProductDetailDTO>> CreateProductAsync(CreateProductDTO product);

        Task<ServiceResponse<ProductDetailDTO>> DeleteProductAsync(int productId);


        Task<ServiceResponse<ProductDetailDTO>> UpdateProductAsync(int id, UpdateProductDTO product);
        Task<int> GetCountProduct();

        Task<ServiceResponse<IEnumerable<ProductDetailDTO>>> GetTop5BestSelling();

        Task<ServiceResponse<IEnumerable<decimal>>> GetRevenueForMonth();
    }
}
