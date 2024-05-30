using Application.Interfaces;
using Application.ViewModels.ShipCompanyDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class ShipCompanysController : BaseController
    {

        private readonly IShipCompanyService _shipCompanyService;
        public ShipCompanysController(IShipCompanyService shipCompanyService )
        {
            _shipCompanyService = shipCompanyService;
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
                return BadRequest();
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
        public async Task<IActionResult> DeletedShipCompany(int Id)
        {
            var c = await _shipCompanyService.DeleteShipCompanyAsync(Id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
