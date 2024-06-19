using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class ShipCompanyRepository : GenericRepository<ShipCompany>, IShipCompanyRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public ShipCompanyRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService)
        : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }
    }
}
