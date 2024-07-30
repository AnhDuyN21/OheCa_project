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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTotalRevenue()
        {
            var result = await _productService.GetTotalRevenue();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RevenueForWeek()
        {
            var result = await _productService.GetRevenueForWeek();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCountProductDiscount()
        {
            var result = await _productService.GetCountProductDiscount();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCountProductSold()
        {
            var result = await _productService.GetCountProductSold();
            return Ok(result);
        }

    }
}
