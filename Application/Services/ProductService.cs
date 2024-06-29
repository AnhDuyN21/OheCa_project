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
using System.Drawing.Printing;
using System.Linq;
using System.Net.WebSockets;
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


        async Task<ServiceResponse<IEnumerable<ProductDTO>>> IProductService.GetProductsAsync(int? pageIndex, int? pageSize)
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDTO>>();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductAsync(pageIndex, pageSize);
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDTO>(product));
                }
                if (productDTOs.Count > 0)
                {
                    reponse.Data = productDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {productDTOs.Count} product.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {productDTOs.Count} product.";
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

        public async Task<ServiceResponse<IEnumerable<ProductDetailDTO>>> GetProductByCategoryAsync(int childCategoryId, int? pageIndex = null, int? pageSize = null)
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDetailDTO>>();
            List<ProductDetailDTO> productDTOs = new List<ProductDetailDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductByCategoryAsync(childCategoryId, pageIndex, pageSize);
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

                newproduct.PriceSold = newproduct.UnitPrice - (newproduct.UnitPrice * newproduct.DiscountPercent);

                await _unitOfWork.ProductRepository.AddAsync(newproduct);
                await _unitOfWork.SaveChangeAsync();

                if (product.Images != null && product.Images.Count > 0)
                {
                    
                    foreach( var image in product.Images )
                    {
                     
                        await _unitOfWork.ImageRepository.CreateImageAsync(image, newproduct.Id);
                    }
                    var productafter = await _unitOfWork.ProductRepository.GetProductByIDAsync(newproduct.Id);
                    reponse.Data = _mapper.Map<ProductDetailDTO>(productafter);
                    reponse.Success = true;
                    reponse.Message = "Create new product successfully";
                    reponse.Error = string.Empty;
                    return reponse;
                }                

            }
            catch (Exception ex) 
            { 
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }

        public async Task<ServiceResponse<ProductDetailDTO>> DeleteProductAsync(int productId)
        {
            var _response = new ServiceResponse<ProductDetailDTO>();
            var product = await _unitOfWork.ProductRepository.GetProductByIDAsync(productId);

            if (product != null)
            {
                _unitOfWork.ProductRepository.SoftRemove(product);
                await _unitOfWork.SaveChangeAsync();

                _response.Data = _mapper.Map<ProductDetailDTO>(product); 
                _response.Success = true;
                _response.Message = "Deleted Product Successfully!";
            }
            else
            {
                _response.Success = false;
                _response.Message = "Product not found";
            }

            return _response;
        }

        public async Task<ServiceResponse<ProductDetailDTO>> UpdateProductAsync(int id, UpdateProductDTO product)
        {
            var reponse = new ServiceResponse<ProductDetailDTO>();

            try
            {
                var productById = await _unitOfWork.ProductRepository.GetByIdAsync(id);

                if (productById != null)
                {
                    var newproduct = _mapper.Map(product, productById);
                    var productafter = _mapper.Map<Product>(newproduct);

                    productafter.PriceSold = productafter.UnitPrice - (productafter.UnitPrice * productafter.DiscountPercent);

                    _unitOfWork.ProductRepository.Update(newproduct);
                    await _unitOfWork.SaveChangeAsync();

                    if (product.ProductMaterials == null || product.ProductMaterials.Count == 0)
                    {
                        await _unitOfWork.SaveChangeAsync();
                    }
                    else
                    {
                        if (product.ProductMaterials.Count > 0 || product.ProductMaterials != null)
                        {
                            foreach(var productMaterial in product.ProductMaterials)
                            {
                                var productMaterialById = await _unitOfWork.ProductMaterialRepository.GetByIdAsync(productMaterial.Id);
                                var newProMaterial = _mapper.Map(productMaterial, productMaterialById);
                                var proMaterialAfter = _mapper.Map<ProductMaterial>(newProMaterial);
                                _unitOfWork.ProductMaterialRepository.Update(proMaterialAfter);
                                await _unitOfWork.SaveChangeAsync();
                            }

                        }
                    }
                    if (product.Images == null || product.Images.Count == 0)
                    {
                        await _unitOfWork.SaveChangeAsync();

                    }
                    else
                    {
                      await  _unitOfWork.ImageRepository.DeleteImageAsync(id);                                        

                        if (product.Images != null && product.Images.Count > 0)
                        {

                            foreach (var image in product.Images)
                            {

                                await _unitOfWork.ImageRepository.CreateImageAsync(image, id);
                            }
                            var productrespone = await _unitOfWork.ProductRepository.GetProductByIDAsync(id);
                            reponse.Data = _mapper.Map<ProductDetailDTO>(productafter);
                            reponse.Success = true;
                            reponse.Message = "Updated product successfully";
                            reponse.Error = string.Empty;
                            return reponse;
                        }
                    }
                }

            }catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }


        public async Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductByDiscountAsync(int? pageIndex = null, int? pageSize = null)
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDTO>>();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductByDiscount(pageIndex, pageSize);
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDTO>(product));
                }
                if (productDTOs.Count > 0)
                {
                    reponse.Data = productDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {productDTOs.Count} product.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {productDTOs.Count} product.";
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

        public async Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductByBrand(int brandId, int? pageIndex = null, int? pageSize = null)
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDTO>>();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductByBrand(brandId, pageIndex, pageSize);
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDTO>(product));
                }
                if (productDTOs.Count > 0)
                {
                    reponse.Data = productDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {productDTOs.Count} product.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {productDTOs.Count} product.";
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

        public async Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductByFeedback(int rate, int? pageIndex = null, int? pageSize = null)
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDTO>>();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductByFeedback(rate, pageIndex, pageSize);
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDTO>(product));
                }
                if (productDTOs.Count > 0)
                {
                    reponse.Data = productDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {productDTOs.Count} product.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {productDTOs.Count} product.";
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

        public async Task<ServiceResponse<IEnumerable<ProductDTO>>> GetProductByChildCategory(int childcategoryId, int? pageIndex = null, int? pageSize = null)
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDTO>>();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductByChildCategory(childcategoryId, pageIndex, pageSize);
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDTO>(product));
                }
                if (productDTOs.Count > 0)
                {
                    reponse.Data = productDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {productDTOs.Count} product.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {productDTOs.Count} product.";
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

    }
}
