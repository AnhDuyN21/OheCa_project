using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<bool> CheckEmailNameExited(string username);
        Task<bool> CheckPhoneNumberExited(string phonenumber);
        Task<User> GetUserByConfirmationToken(string token);
    }
}
