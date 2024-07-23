using Application.Interfaces;
using Application.Services;
using Application.ViewModels.AddressToShipDTOs;
using Application.ViewModels.ShipCompanyDTOs;
using Application.ViewModels.ShipperDTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class AddressToShipsController : BaseController
    {
        private readonly IAddressToShipService _addressToShipService;
        private readonly IValidator<CreateAddressToShipDTO> _validator;
        private readonly IValidator<UpdateAddressToShipDTO> _validatorUpdate;

        public AddressToShipsController(IAddressToShipService addressToShipService, IValidator<CreateAddressToShipDTO> validator, IValidator<UpdateAddressToShipDTO> validatorUpdate)
        {
            _addressToShipService = addressToShipService;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllAddressToShips()
        {
            var result = await _addressToShipService.GetAddressToShipAsync();
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
        public async Task<IActionResult> ViewAddressToShipByID(int Id)
        {
            var result = await _addressToShipService.GetAddressToShipByIdAsync(Id);
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

        //[HttpGet("{UserId:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> SearchAddressToShipByName(int UserId)
        //{
        //    var result = await _addressToShipService.GetAddressToShipByUserIDAsync(UserId);
        //    if (result == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }
        //    return Ok(result);
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAddressToShip([FromBody] CreateAddressToShipDTO createDto)
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
            var c = await _addressToShipService.CreateAddressToShipAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAddressToShip(int id, [FromBody] UpdateAddressToShipDTO updateDto)
        {
            ValidationResult result = await _validatorUpdate.ValidateAsync(updateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var c = await _addressToShipService.UpdateAddressToShipAsync(id, updateDto);
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
            var c = await _addressToShipService.DeleteAddressToShipAsync(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
