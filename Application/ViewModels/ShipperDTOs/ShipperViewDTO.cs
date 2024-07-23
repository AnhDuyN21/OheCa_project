using Application.ViewModels.ShipCompanyDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ShipperDTOs
{
    public class ShipperViewDTO
    {
        public int Id { get; set; }
        public int? ShipCompanyId { get; set; }

        public string? Phone { get; set; }

        public string? Name { get; set; }

    }
}
