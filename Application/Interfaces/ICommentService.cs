using Application.Repositories;
using Application.ServiceResponse;
using Application.ViewModels.CommentDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Task<ServiceResponse<IEnumerable<CommentDTO>>> GetCommnetByPostId(int postId);
        Task<ServiceResponse<CommentDTO>> CreateCommentAsync(int postId, CreateCommentDTO createCommentDTO);
        Task<ServiceResponse<bool>> DeleteCommentAsync(int id);
    }
}
