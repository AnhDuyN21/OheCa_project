using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class DashboardsController : BaseController
    {
        private readonly IProductService _productService;

        public DashboardsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Top5Products()
        {
            var result = await _productService.GetTop5BestSelling();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RevenueForMonth()
        {
            var result = await _productService.GetRevenueForMonth();
            return Ok(result);
        }
    }
}
