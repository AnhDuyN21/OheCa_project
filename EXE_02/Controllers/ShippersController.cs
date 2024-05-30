using Application.Interfaces;
using Application.Services;
using Application.ViewModels.ShipCompanyDTOs;
using Application.ViewModels.ShipperDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class ShippersController : BaseController
    {
        private readonly IShipperService _shipperService;
        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllShippers()
        {
            var result = await _shipperService.GetShippersAsync();
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
        public async Task<IActionResult> ViewShipperByID(int Id)
        {
            var result = await _shipperService.GetShipperByIdAsync(Id);
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
        public async Task<IActionResult> SearchShipperByName(string name)
        {
            var result = await _shipperService.searchShippersByNameAsync(name);
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
        public async Task<IActionResult> CreateShipper([FromBody] CreateShipperDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            var c = await _shipperService.CreateShipperAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateShipper(int id, [FromBody] UpdateShipperDTO updateDto)
        {
            var c = await _shipperService.UpdateShippperAsync (id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedShipper(int Id)
        {
            var c = await _shipperService.DeleteShipperAsync(Id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
