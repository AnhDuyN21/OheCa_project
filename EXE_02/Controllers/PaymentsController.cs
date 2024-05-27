using Application.Interfaces;
using Application.Services;
using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.PaymentDTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    
    public class PaymentsController : BaseController
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService) 
        {
           _paymentService = paymentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllPayments()
        {
            var result = await _paymentService.GetPaymentsAsync();
            if (result == null)
            {
                return BadRequest();
            }
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{paymentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllPaymentByPaymentID(int paymentId)
        {
            var result = await _paymentService.GetPaymentByIdAsync(paymentId);
            if (result == null)
            {
                return BadRequest();
            }
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{method:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchPaymentByName(string method)
        {
            var result = await _paymentService.searchPaymentByNameAsync(method);
            if (result == null)
            {
                return BadRequest();
            }
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreatePaymentDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            var c = await _paymentService.CreatePaymentAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] UpdatePaymentDTO updateDto)
        {
            var c = await _paymentService.UpdatePaymentAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedPaymentByid(int paymentId)
        {
            var c = await _paymentService.DeletePaymentAsync(paymentId);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
