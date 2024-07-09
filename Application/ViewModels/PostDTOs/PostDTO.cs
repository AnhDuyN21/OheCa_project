using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PostDTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int LikeQuantity { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDay { get; set; }
    }
}
