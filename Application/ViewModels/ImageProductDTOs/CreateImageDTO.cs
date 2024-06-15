using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ImageProductDTOs
{
    public class CreateImageDTO
    {
        public IFormFile File { get; set; }
        public bool Thumbnail { get; set; }
    }
}
