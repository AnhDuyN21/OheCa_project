using Application.ServiceResponse;
using Application.ViewModels.ImageProductDTOs;
using Application.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IImageService
    {
        public Task<ServiceResponse<ImageDTO>> CreateImageAsync(IFormFile[] fileCollection, int productId);
    }
}
