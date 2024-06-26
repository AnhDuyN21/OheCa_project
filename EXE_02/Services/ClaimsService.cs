﻿using Application.Interfaces;
using System.Security.Claims;

namespace EXE_02.Services
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("userId");
            GetCurrentUserId = string.IsNullOrEmpty(Id) ? 0 : int.Parse(Id);
        }

        public int? GetCurrentUserId { get; }

    }

}
