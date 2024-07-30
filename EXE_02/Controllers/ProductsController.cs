using Application.Interfaces;
using Application.Services;
using Application.ViewModels.ProductDTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
           _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllProduct(int? pageIndex, int?pageSize)
        {
            var result = await _productService.GetProductsAsync(pageIndex, pageSize);
            return Ok(result);
        }

       
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewProductByID(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("{childCategoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewProductByCategoryID(int childCategoryId, int? pageIndex, int? pageSize)
        {
            var result = await _productService.GetProductByCategoryAsync(childCategoryId, pageIndex, pageSize);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProductAsync([FromForm]CreateProductDTO product)
        {
            var result = await _productService.CreateProductAsync(product);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            var result = await _productService.DeleteProductAsync(productId);
            return Ok(result);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProductAsync(int id,[FromForm]UpdateProductDTO product)
        {
            var result = await _productService.UpdateProductAsync(id ,product);
            return Ok(result);
        }


        [HttpGet("{childCategoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewProductByChildCategoryID(int childCategoryId, int? pageIndex, int? pageSize)
        {
            var result = await _productService.GetProductByChildCategory(childCategoryId, pageIndex, pageSize);
            return Ok(result);
        }


        [HttpGet("{brandId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewProductByBrandID(int brandId, int? pageIndex, int? pageSize)
        {
            var result = await _productService.GetProductByBrand(brandId, pageIndex, pageSize);
            return Ok(result);
        }

        [HttpGet("{rate:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewProductByRate(int rate, int? pageIndex, int? pageSize)
        {
            var result = await _productService.GetProductByFeedback(rate, pageIndex, pageSize);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewProductByDiscount(int? pageIndex, int? pageSize)
        {
            var result = await _productService.GetProductByDiscountAsync(pageIndex, pageSize);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCountProduct()
        {
            var result = await _productService.GetCountProduct();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts(int? brandId, int? categoryId)
        {
            var result = await _productService.GetProductsForAdminAsync(brandId, categoryId);
            return Ok(result);
        }

      

    }
}
