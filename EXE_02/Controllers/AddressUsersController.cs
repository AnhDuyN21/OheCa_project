using Application.Interfaces;
using Application.Services;
using Application.ViewModels.AddressToShipDTOs;
using Application.ViewModels.AddressUserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class AddressUsersController : BaseController
    {
        private readonly IAddressUserService _addressUserService;
        public AddressUsersController(IAddressUserService addressUserService)
        {
            _addressUserService = addressUserService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAddressUser([FromBody] CreateAddressUserDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            var c = await _addressUserService.CreateAddressUserAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAddressUser(int id, [FromBody] UpdateAddressUserDTO updateDto)
        {
            var c = await _addressUserService.UpdateAddressUserAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedAddressUser(int id)
        {
            var c = await _addressUserService.DeleteAddressUserAsync(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
