using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PostDTOs
{
    public class CreatePostDTO
    {
        [Required]
        public string Title {  get; set; }
        [Required]
        public string Content {  get; set; }
    }
}
