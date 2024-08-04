using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class ChildCategoriesController : BaseController
    {
        private readonly IProductService _productService;

        public ChildCategoriesController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetChildCategories()
        {
            var result = await _productService.GetChildCategoryAsync();
            return Ok(result);
        }
    }
}
