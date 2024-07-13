using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.CommentDTOs
{
    public class CreateCommentDTO
    {
        [Required]
        public string Content {  get; set; }
    }
}
