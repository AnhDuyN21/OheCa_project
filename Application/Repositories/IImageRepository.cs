using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        public Task<Image> CreateImageAsync(IFormFile file, int productId);
    }
}
