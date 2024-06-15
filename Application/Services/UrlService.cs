using Application.Interfaces;
using Application.ServiceResponse;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UrlService : IUrlService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetHostUrl()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            return  $"{request.Scheme}://{request.Host}{request.PathBase}";
        }
    }
}
