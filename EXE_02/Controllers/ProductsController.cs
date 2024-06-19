using Application.Interfaces;
using Application.Services;
using Application.ViewModels.ProductDTOs;
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
        public async Task<IActionResult> ViewAllProduct()
        {
            var result = await _productService.GetProductsAsync();
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
        public async Task<IActionResult> ViewProductByCategoryID(int childCategoryId)
        {
            var result = await _productService.GetProductByCategoryAsync(childCategoryId);
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
        public async Task<IActionResult> ViewProductByChildCategoryID(int childCategoryId)
        {
            var result = await _productService.GetProductByChildCategory(childCategoryId);
            return Ok(result);
        }


        [HttpGet("{brandId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewProductByBrandID(int brandId)
        {
            var result = await _productService.GetProductByBrand(brandId);
            return Ok(result);
        }

        [HttpGet("{rate:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewProductByRate(int rate)
        {
            var result = await _productService.GetProductByFeedback(rate);
            return Ok(result);
        }

        


    }
}
