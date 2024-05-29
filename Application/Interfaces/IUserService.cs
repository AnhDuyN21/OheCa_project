using Application.ServiceResponse;
using Application.ViewModels.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<UserDTO>>> GetUserAsync();
        Task<ServiceResponse<UserDTO>> GetUserByIdAsync(int id);
        Task<ServiceResponse<UserDTO>> UpdateUserAsync(int id, UserDTO userDTO);
        Task<ServiceResponse<bool>> DeleteUserAsync(int id);
        Task<ServiceResponse<IEnumerable<UserDTO>>> SearchUserByNameAsync(string name);
        Task<ServiceResponse<UserDTO>> CreateAccountAsync(CreateUserDTO createdUserDTO);
        //Task<ServiceResponse<UserDTO>> UpdateAvatarAsync(int id, string avatarUrl);

    }
}
