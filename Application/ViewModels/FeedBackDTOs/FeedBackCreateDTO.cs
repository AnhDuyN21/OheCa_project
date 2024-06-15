using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FeedBackDTOs
{
    public class FeedBackCreateDTO
    {
        public int? UserId { get; set; }

        public string? Content { get; set; }

        public int? Rate { get; set; }

        public int? ProductId { get; set; }

    }
}
