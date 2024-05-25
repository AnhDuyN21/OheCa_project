using Application.ServiceResponse;
using Application.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUrlService
    {
        string GetHostUrl();
    }
}
