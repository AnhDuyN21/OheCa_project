using Application.ServiceResponse;
using Application.ViewModels.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<ServiceResponse<UserDTO>> RegisterAsync(RegisterUserDTO registerUserDTO);
        public Task<ServiceResponse<AuthResponseDTO>> LoginAsync(AuthenUserDTO usertDTO);
    }
}
