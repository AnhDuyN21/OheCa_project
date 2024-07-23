using Application.Interfaces;
using Application.Services;
using Application.ViewModels.OrderDetailDTOs;
using Application.ViewModels.PaymentDTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    
    public class PaymentsController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly IValidator<CreatePaymentDTO> _validator;
        private readonly IValidator<UpdatePaymentDTO> _validatorUpdate;

        public PaymentsController(IPaymentService paymentService, IValidator<CreatePaymentDTO> validator, IValidator<UpdatePaymentDTO> validatorUpdate)
        {
            _paymentService = paymentService;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
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

        [HttpGet("{method}")]
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
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDTO createDto)
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
            ValidationResult result = await _validatorUpdate.ValidateAsync(updateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
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
        public async Task<IActionResult> DeletedPaymentByid(int id)
        {
            var c = await _paymentService.DeletePaymentAsync(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
