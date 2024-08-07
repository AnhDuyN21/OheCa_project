﻿using Application.Interfaces;
using Application.ViewModels.ShipCompanyDTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class ShipCompanysController : BaseController
    {

        private readonly IShipCompanyService _shipCompanyService;
        private readonly IValidator<CreateShipCompanyDTO> _validator;
        private readonly IValidator<UpdateShipCompanyDTO> _validatorUpdate;

        public ShipCompanysController(IShipCompanyService shipCompanyService, IValidator<CreateShipCompanyDTO> validator, IValidator<UpdateShipCompanyDTO> validatorUpdate)
        {
            _shipCompanyService = shipCompanyService;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllShipCompanys()
        {
            var result = await _shipCompanyService.GetShipCompanysAsync();
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
        public async Task<IActionResult> ViewShipCompanyByID(int Id)
        {
            var result = await _shipCompanyService.GetShipCompanyByIdAsync(Id);
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

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchShipCompanyByName(string name)
        {
            var result = await _shipCompanyService.searchShipCompanyByNameAsync(name);
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
        public async Task<IActionResult> CreateShipCompany([FromBody] CreateShipCompanyDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            ValidationResult result = await _validator.ValidateAsync(createDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var c = await _shipCompanyService.CreateShipCompanyAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }

            return Ok(c);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateShipCompany(int id, [FromBody] UpdateShipCompanyDTO updateDto)
        {
            ValidationResult result = await _validatorUpdate.ValidateAsync(updateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var c = await _shipCompanyService.UpdateShipCompanyAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }

            return Ok(c);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedShipCompany(int id)
        {
            var c = await _shipCompanyService.DeleteShipCompanyAsync(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
