using Application.Interfaces;
using Application.Services;
using Application.ViewModels.ShipperDTOs;
using Application.ViewModels.VoucherDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    
    public class VouchersController : BaseController
    {
        private readonly IVoucherService _voucherService;
        public VouchersController(IVoucherService voucherService) 
        {
             _voucherService = voucherService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllVouchers()
        {
            var result = await _voucherService.GetVoucherAsync();
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
        public async Task<IActionResult> ViewVoucherByID(int Id)
        {
            var result = await _voucherService.GetVoucherByIdAsync(Id);
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

        [HttpGet("{orderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchVoucherIsUsedByUser(int orderId)
        {
            var result = await _voucherService.GetVoucherIsUsedByOrderByUserIDAsync(orderId);
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
        public async Task<IActionResult> CreateVoucher([FromBody] CreateVoucherDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            var c = await _voucherService.CreateVoucherAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVoucher(int id, [FromBody] UpdateVoucherDTO updateDto)
        {
            var c = await _voucherService.UpdateVoucherAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedVoucher(int Id)
        {
            var c = await _voucherService.DeleteVoucherAsync(Id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

    }
}
