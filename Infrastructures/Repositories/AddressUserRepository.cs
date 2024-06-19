using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class AddressUserRepository : GenericRepository<AddressUser> , IAddressUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public AddressUserRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
        : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }
    }
}
