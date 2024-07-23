using Application.ViewModels.PostDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<PostWithUserDTO>> SearchPostByTitleAsync(string title);
        Task<IEnumerable<PostWithUserDTO>> GetAllPostWithUsernameAndAvatar();
    }
}
