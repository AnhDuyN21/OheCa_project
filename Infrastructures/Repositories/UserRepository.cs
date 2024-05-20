using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }
        public Task<bool> CheckEmailNameExited(string email) =>
        _dbContext.Users.AnyAsync(u => u.Email == email);

        public Task<bool> CheckPhoneNumberExited(string phonenumber) =>
        _dbContext.Users.AnyAsync(u => u.Phone == phonenumber);

        public Task<bool> FindUserById(int userId) =>
        _dbContext.Users.AnyAsync(u => u.Id == userId);

        public async Task<User> GetUserByEmailAndPasswordHash(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync( record => record.Email == email && record.Password == password );
            if (user is null)
            {
                throw new Exception("Email & password is not correct");
            }

            return user;
        }

        public async Task<User> GetUserByConfirmationToken(string token)
        {
            return await _dbContext.Users.SingleOrDefaultAsync( u => u.ConfirmToken == token );
        }

        public async Task<IEnumerable<User>> SearchAccountByNameAsync(string name)
        {
            return await _dbContext.Users.Where(u => u.FirstName.Contains(name) || u.LastName.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchAccountByRoleNameAsync(string roleName)
        {
            return await _dbContext.Users.Where(u => u.Role.Contains(roleName))
                .ToListAsync();
        }
    }
}
