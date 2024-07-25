using Application.Interfaces;
using Application.ViewModels.OrderDTOs;
using Application.ViewModels.ShipCompanyDTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IValidator<CreateOrderDTO> _validator;
        private readonly IValidator<UpdateOrderDTO> _validatorUpdate;

        public OrdersController(IOrderService orderService, IValidator<CreateOrderDTO> validator, IValidator<UpdateOrderDTO> validatorUpdate)
        {
            _orderService = orderService;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
        }


        //[Authorize(Roles = "Manager, Customer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllOrder()
        {
            var result = await _orderService.GetOrdersAsync();
            return Ok(result);
        }

        //[Authorize(Roles = "Customer")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllOrderByUserID(int id)
        {
            var result = await _orderService.GetOrderByUserIDAsync(id);
            return Ok(result);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewOrderByID(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            return Ok(result);
        }

        //[Authorize (Roles = "Manager")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO createDto)
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
            var c = await _orderService.CreateOrderAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        //[Authorize(Roles = "Manager")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDTO updateDto)
        {
            ValidationResult result = await _validatorUpdate.ValidateAsync(updateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var c = await _orderService.UpdateOrderAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        //[Authorize(Roles = "Manager, Customer")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var c = await _orderService.CancelOrderAsync(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CheckOut([FromBody] CheckoutDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            //ValidationResult result = await _validator.ValidateAsync(createDto);

            //if (!result.IsValid)
            //{
            //    return BadRequest(result.Errors);
            //}
            var c = await _orderService.CheckoutAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmOrder(int id)
        {
            var c = await _orderService.ConfirmOrder(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
