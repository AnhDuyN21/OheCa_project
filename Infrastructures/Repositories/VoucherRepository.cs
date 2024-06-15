using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class VoucherRepository : GenericRepository<Voucher> , IVoucherRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public VoucherRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
        : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }
    }
}
