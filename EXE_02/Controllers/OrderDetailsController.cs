using Application.Interfaces;
using Application.Services;
using Application.ViewModels.OrderDetailDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class OrderDetailsController : BaseController
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllOrderDetails()
        {
            var result = await _orderDetailService.GetOrderDetailsAsync();
            return Ok(result);
        }

        [HttpGet("{orderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllOrderDetailByOrderID(int orderId)
        {
            var result = await _orderDetailService.GetOrderDetailByOrderIdsAsync(orderId);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllOrderDetailByID(int orderDetailId)
        {
            var result = await _orderDetailService.GetOrderDetailByIdAsync(orderDetailId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            var c = await _orderDetailService.CreateOrderDetailAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] UpdateOrderDetailDTO updateDto)
        {
            var c = await _orderDetailService.UpdateOrderDetailAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedSoftRangeOrderDetailByOrderID(int orderId)
        {
            var c = await _orderDetailService.DeletedOrderDetailRange(orderId);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
