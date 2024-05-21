using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.UserDTO
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        
        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public int? RoleId { get; set; }
        public int Status { get; set; }
    }
}
