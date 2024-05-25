using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.DiscountDTOs;
using Application.ViewModels.FeedbackDTOs;
using Application.ViewModels.ImageProductDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.ProductDTOs;
using Application.ViewModels.ProductMaterialDTOs;
using AutoMapper;
using Azure;
using Domain.Entities;
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

 
        

        

        async Task<ServiceResponse<IEnumerable<ProductDTO>>> IProductService.GetProductsAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDTO>>();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductAsync();
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

        public async Task<ServiceResponse<IEnumerable<ProductDetailDTO>>> GetProductByCategoryAsync(int childCategoryId)
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDetailDTO>>();
            List<ProductDetailDTO> productDTOs = new List<ProductDetailDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductByCategoryAsync(childCategoryId);
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDetailDTO>(product));
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
                    reponse.Message = $"Have {productDTOs.Count} products.";
                    reponse.Error = "Not have a product";
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

        public async Task<ServiceResponse<ProductDetailDTO>> CreateProductAsync(CreateProductDTO product)
        {
            var reponse = new ServiceResponse<ProductDetailDTO>();
           

            try
            {
                var newproduct = _mapper.Map<Product>(product);

                await _unitOfWork.ProductRepository.AddAsync(newproduct);
                await _unitOfWork.SaveChangeAsync();
                if (product.Images != null && product.Images.Length > 0)
                {
                    
                    foreach( var image in product.Images )
                    {
                     //   imageDTOs.Add(_mapper.Map<ImageDTO>(image));
                        await _unitOfWork.ImageRepository.CreateImageAsync(image, newproduct.Id);
                    }
                    

                    reponse.Data = _mapper.Map<ProductDetailDTO>(newproduct);
                    reponse.Success = true;
                    reponse.Message = "Create new product successfully";
                    reponse.Error = string.Empty;
                    return reponse;
                }

            }catch (Exception ex) 
            { 
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }
    }
}
