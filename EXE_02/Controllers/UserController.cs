using Application.Interfaces;
using Application.ViewModels.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountList()
        {
            var User = await _userService.GetUserAsync();
            return Ok(User);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var findaccountUser = await _userService.GetUserByIdAsync(id);
            if (!findaccountUser.Success)
            {
                return NotFound(findaccountUser);
            }
            return Ok(findaccountUser);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var result = await _userService.SearchUserByNameAsync(name);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

         [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createdUserDTO)
        {
            //Dòng này kiểm tra xem dữ liệu đầu vào (trong trường hợp này là createdAccountDTO)
            //đã được kiểm tra tính hợp lệ bằng các quy tắc mô hình (model validation) hay chưa.
            //Nếu dữ liệu hợp lệ, nó tiếp tục kiểm tra và xử lý.
            if (ModelState.IsValid)
            {
                var response = await _userService.CreateAccountAsync(createdUserDTO);
                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            else
            {
                return BadRequest("Invalid request data.");
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, userDTO);
            if (!updatedUser.Success)
            {
                return NotFound(updatedUser);
            }
            return Ok(updatedUser);
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _userService.DeleteUserAsync(id);
            if (!deletedUser.Success)
            {
                return NotFound(deletedUser);
            }
            
            return Ok(deletedUser);
        }
    }
}
