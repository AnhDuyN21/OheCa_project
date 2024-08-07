﻿using Application.ServiceResponse;
using Application.ViewModels.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        Task<ServiceResponse<IEnumerable<PostWithUserDTO>>> GetAllPostAsync();
        Task<ServiceResponse<IEnumerable<PostWithUserDTO>>> SearchPostByTitleAsync(string title);
        Task<ServiceResponse<PostDTO>> GetPostByPostIdAsync(int id);
        Task<ServiceResponse<bool>> DeletePostAsync(int id); 
        Task<ServiceResponse<PostDTO>> CreatePostAsync(CreatePostDTO createPostDTO);
        Task<ServiceResponse<PostDTO>> UpdatePostAsync(int id, UpdatePostDTO updatePostDTO);
        Task<ServiceResponse<IEnumerable<PostDTO>>> GetPostByUserIdAsync();
        Task<ServiceResponse<bool>> LikePostAsync(int postId);
    }
}
