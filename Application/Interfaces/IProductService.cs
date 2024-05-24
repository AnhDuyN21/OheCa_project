using Application.ServiceResponse;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.ProductDTOs;
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
        Task<ServiceResponse<OrderDTO>> CreateOrderAsync(CreateOrderDTO order);
        Task<ServiceResponse<OrderDTO>> UpdateOrderAsync(int id, UpdateOrderDTO order);
        Task<ServiceResponse<bool>> CancelOrderAsync(int id);
        Task<ServiceResponse<IEnumerable<OrderDTO>>> GetSortedOrdersAsync(string sortName);
    }
}
