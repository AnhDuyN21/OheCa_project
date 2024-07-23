using Application.Interfaces;
using Application.Services;
using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.ShipCompanyDTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class OrderDetailsController : BaseController
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IValidator<CreateOrderDetailDTO> _validator;
        private readonly IValidator<UpdateOrderDetailDTO> _validatorUpdate;

        public OrderDetailsController(IOrderDetailService orderDetailService, IValidator<CreateOrderDetailDTO> validator, IValidator<UpdateOrderDetailDTO> validatorUpdate)
        {
            _orderDetailService = orderDetailService;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
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
            ValidationResult result = await _validator.ValidateAsync(createDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
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
            ValidationResult result = await _validatorUpdate.ValidateAsync(updateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
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
        public async Task<IActionResult> DeletedSoftRangeOrderDetailByOrderID(int id)
        {
            var c = await _orderDetailService.DeletedOrderDetailRange(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
