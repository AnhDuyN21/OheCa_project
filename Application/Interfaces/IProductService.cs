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
        Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductsAsync();
        Task<ServiceResponse<ProductDetailDTO>> GetProductByIdAsync(int productId);
        Task<ServiceResponse<IEnumerable<ProductDetailDTO>>> GetProductByCategoryAsync(int userId);
        Task<ServiceResponse<ProductDetailDTO>> CreateProductAsync(CreateProductDTO product);

        Task<ServiceResponse<ProductDetailDTO>> DeleteProductAsync(int productId);


        Task<ServiceResponse<ProductDetailDTO>> UpdateProductAsync(int id, UpdateProductDTO product);
    }
}
