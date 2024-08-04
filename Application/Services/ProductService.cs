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
using static Google.Apis.Requests.BatchRequest;


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
        public async Task<int> GetCountProduct()
        {
            var getAllProduct = await _unitOfWork.ProductRepository.GetAllAsync();
            return getAllProduct.Count;
        }

        public async Task<ServiceResponse<IEnumerable<ProductDetailDTO>>> GetProductsForAdminAsync(int? brandId = null, int? categoryId = null)
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDetailDTO>>();
            List<ProductDetailDTO> productDTOs = new List<ProductDetailDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProductForAdminAsync(brandId, categoryId);
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDetailDTO>(product));
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

        public async Task<ServiceResponse<IEnumerable<ProductDetailDTO>>> GetTop5BestSelling()
        {
            var reponse = new ServiceResponse<IEnumerable<ProductDetailDTO>>();
            List<ProductDetailDTO> productDTOs = new List<ProductDetailDTO>();
            try
            {
                var products = await _unitOfWork.ProductRepository.GetTop5BestProductSelling();
                foreach (var product in products)
                {
                    productDTOs.Add(_mapper.Map<ProductDetailDTO>(product));
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

        public async Task<ServiceResponse<IEnumerable<decimal>>> GetRevenueForMonth()
        {
            var reponse = new ServiceResponse<IEnumerable<decimal>>();
            List<decimal> revenueDTOs = new List<decimal>();
            try
            {
                var revenues = await _unitOfWork.ProductRepository.GetRevenueForMonth();
                foreach (var revenueForEachMonth in revenues)
                {
                    revenueDTOs.Add(_mapper.Map<decimal>(revenueForEachMonth));
                }
                if (revenueDTOs.Count > 0)
                {
                    reponse.Data = revenueDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {revenueDTOs.Count} revenues.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {revenueDTOs.Count} revenue.";
                    reponse.Error = "Not have a revenue";
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

        public async Task<ServiceResponse<decimal>> GetTotalRevenue()
        {
            var reponse = new ServiceResponse<decimal>();
           
            try
            {
                var revenues = await _unitOfWork.ProductRepository.GetTotalRevenue();
                
                if (revenues != null)
                {
                    reponse.Data = revenues;
                    reponse.Success = true;
                    reponse.Message = $"Have revenues.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have not revenue.";
                    reponse.Error = "Not have a revenue";
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

        public async Task<ServiceResponse<IEnumerable<decimal>>> GetRevenueForWeek()
        {
            var reponse = new ServiceResponse<IEnumerable<decimal>>();
            List<decimal> revenueDTOs = new List<decimal>();
            try
            {
                var revenues = await _unitOfWork.ProductRepository.GetRevenueForWeek();
                foreach (var revenueForEachMonth in revenues)
                {
                    revenueDTOs.Add(_mapper.Map<decimal>(revenueForEachMonth));
                }
                if (revenueDTOs.Count > 0)
                {
                    reponse.Data = revenueDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {revenueDTOs.Count} revenues.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {revenueDTOs.Count} revenue.";
                    reponse.Error = "Not have a revenue";
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

        public async Task<int> GetCountProductDiscount()
        {
            var getAllProduct = await _unitOfWork.ProductRepository.GetProductdDiscountAsync();
            return getAllProduct.Count();
        }


        public async Task<ServiceResponse<ProductDetailDTO>> UpdateQuanityAsync(int id, int quantity)
        {
            var _response = new ServiceResponse<ProductDetailDTO>();
            int? newquantity;
            int? newquantitysold;
            try
            {
                var productById = await _unitOfWork.ProductRepository.GetByIdAsync(id);

                if (productById != null)
                {
                    newquantity = productById.Quantity - quantity;
                    newquantitysold = productById.QuantitySold + quantity;

                    if (newquantity < 0)
                    {
                        _response.Success = false;
                        _response.Message = "Not Enought Product";

                    }
                    else if (newquantity == 0)
                    {
                        productById.IsDeleted = true;
                        productById.Quantity = newquantity;
                        productById.QuantitySold = newquantitysold;
                        _unitOfWork.ProductRepository.Update(productById);
                        await _unitOfWork.SaveChangeAsync();
                        var productDTO = _mapper.Map<ProductDetailDTO>(productById);


                        _response.Data = productDTO;
                        _response.Success = true;
                        _response.Message = "Found Product By Id";
                    }
                    else
                    {
                        productById.Quantity = newquantity;
                        productById.QuantitySold = newquantitysold;
                        _unitOfWork.ProductRepository.Update(productById);
                        await _unitOfWork.SaveChangeAsync();
                        var productDTO = _mapper.Map<ProductDetailDTO>(productById);


                        _response.Data = productDTO;
                        _response.Success = true;
                        _response.Message = "Found Product By Id";
                    }
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
                return _response;
            }

            return _response;
        }

        public async Task<int> GetCountProductSold()
        {
            var getAllProduct = await _unitOfWork.ProductRepository.GetProductSoldAsync();
            return getAllProduct.Count();
        }

        public async Task<ServiceResponse<IEnumerable<Brand>>> GetBrandAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<Brand>>();
            List<Brand> brandDTOs = new List<Brand>();
            try
            {
                var brands = await _unitOfWork.ProductRepository.GetBrandAsync();
                foreach (var brand in brands)
                {
                    brandDTOs.Add(_mapper.Map<Brand>(brand));
                }
                if (brandDTOs.Count > 0)
                {
                    reponse.Data = brandDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {brandDTOs.Count} brands.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {brandDTOs.Count} brands.";
                    reponse.Error = "Not have a brand";
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


        public async Task<ServiceResponse<IEnumerable<ChildCategory>>> GetChildCategoryAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ChildCategory>>();
            List<ChildCategory> brandDTOs = new List<ChildCategory>();
            try
            {
                var brands = await _unitOfWork.ProductRepository.GetChildCateAsync();
                foreach (var brand in brands)
                {
                    brandDTOs.Add(_mapper.Map<ChildCategory>(brand));
                }
                if (brandDTOs.Count > 0)
                {
                    reponse.Data = brandDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {brandDTOs.Count} ChildCategorys.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {brandDTOs.Count} ChildCategorys.";
                    reponse.Error = "Not have a ChildCategory";
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
