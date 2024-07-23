using Application.Interfaces;
using Application.Services;
using Application.ViewModels.AddressToShipDTOs;
using Application.ViewModels.FeedBackDTOs;
using EXE_02.Validations.FeedBackValidations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
   
    public class FeedbacksController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IValidator<FeedBackCreateDTO> _validator;
        private readonly IValidator<FeedBackUpdateDTO> _validatorUpdate;

        public FeedbacksController(IFeedbackService feedbackService, IValidator<FeedBackCreateDTO> validator, IValidator<FeedBackUpdateDTO> validatorUpdate)
        {
            _feedbackService = feedbackService;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllFeedBacks()
        {
            var result = await _feedbackService.GetFeedbackAsync();
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

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewFeedBackByID(int Id)
        {
            var result = await _feedbackService.GetFeedbackByIdAsync(Id);
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

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewFeedBackByUserID(int Id)
        {
            var result = await _feedbackService.GetFeedbackByUserIDAsync(Id);
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
        public async Task<IActionResult> CreateFeedBack([FromBody] FeedBackCreateDTO createDto)
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
            var c = await _feedbackService.CreateFeedbackAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFeedBack(int id, [FromBody] FeedBackUpdateDTO updateDto)
        {
            ValidationResult result = await _validatorUpdate.ValidateAsync(updateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var c = await _feedbackService.UpdateFeedbackAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedAddressToShip(int id)
        {
            var c = await _feedbackService.DeleteFeedbackAsync(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }


    }
}
