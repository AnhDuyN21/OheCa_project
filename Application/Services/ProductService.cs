using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.DiscountDTOs;
using Application.ViewModels.FeedbackDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.ProductDTOs;
using Application.ViewModels.ProductMaterialDTOs;
using AutoMapper;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        Task<ServiceResponse<bool>> IProductService.CancelOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<OrderDTO>> IProductService.CreateOrderAsync(CreateOrderDTO order)
        {
            throw new NotImplementedException();
        }

        

        Task<ServiceResponse<IEnumerable<OrderDTO>>> IProductService.GetOrderByUserIDAsync(int userId)
        {
            throw new NotImplementedException();
        }

        async Task<ServiceResponse<IEnumerable<ProductDTO>>> IProductService.GetProductsAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDTO>>();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync();
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDTO>(product));
                }
                if (productDTOs.Count > 0)
                {
                    reponse.Data = productDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {productDTOs.Count} order.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {productDTOs.Count} order.";
                    reponse.Error = "Not have a order";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Error = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }

        Task<ServiceResponse<IEnumerable<OrderDTO>>> IProductService.GetSortedOrdersAsync(string sortName)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<OrderDTO>> IProductService.UpdateOrderAsync(int id, UpdateOrderDTO order)
        {
            throw new NotImplementedException();
        }

        async Task<ServiceResponse<ProductDetailDTO>> IProductService.GetProductByIdAsync(int productId)
        {
            var _response = new ServiceResponse<ProductDetailDTO>();


            try
            {
                var product = await _unitOfWork.ProductRepository.GetProductByIDAsync(productId);
                if (product != null)
                {
                    var productDTO = _mapper.Map<ProductDetailDTO>(product);
                //    productDTO.BrandName = product.Brand.Name;
                //    productDTO.Feeback = _mapper.Map<List<FeedbackDTO>>(product.Feedbacks);
                //    productDTO.Discounts = _mapper.Map<List<DiscountDTO>>(product.Discounts);
                 //   productDTO.ProductMaterials = _mapper.Map<List<ProductMaterialDTO>>(product.ProductMaterials);
                    

                    _response.Data = productDTO;
                    _response.Success = true;
                    _response.Message = "Found Product By Id";
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Don't Have Any Product ";
                }
                
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
    }
}
