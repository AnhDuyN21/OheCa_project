using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class BrandsController : BaseController
    {
        private readonly IProductService _productService;

        public BrandsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBrands()
        {
            var result = await _productService.GetBrandAsync();
            return Ok(result);
        }
    }
}
