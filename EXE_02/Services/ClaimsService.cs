using Application.Interfaces;
using System.Security.Claims;

namespace EXE_02.Services
{
    public class ClaimsService : IClaimsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("Id");
            GetCurrentUserId = string.IsNullOrEmpty(Id) ? 0 : int.Parse(Id);

            _httpContextAccessor = httpContextAccessor;
        }

        public int? GetCurrentUserId { get; }

        public int GetUserId()
        {
            var id = _httpContextAccessor.HttpContext?.User?.FindFirstValue("Id");
            return string.IsNullOrEmpty(id) ? 0 : int.Parse(id);
        }
    }

}
