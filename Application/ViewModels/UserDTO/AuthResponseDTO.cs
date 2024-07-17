using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.UserDTO
{
    public class AuthResponseDTO
    {
        public UserDTO User { get; set; }
        public string AccessToken { get; set; }
    }
}
