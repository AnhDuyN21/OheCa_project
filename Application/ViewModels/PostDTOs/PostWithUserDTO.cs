using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PostDTOs
{
    public class PostWithUserDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? LikeQuantity { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
