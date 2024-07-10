﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.CommentDTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content {  get; set; }
        public int PostId {  get; set; }
        public string UserId { get; set; } 
    }
}
