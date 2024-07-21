using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.PostDTOs;

namespace Infrastructures.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly AppDbContext _dbContext;
        public PostRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<PostWithUserDTO>> SearchPostByTitleAsync(string title)
        {

            var results = await _dbContext.Posts.AsQueryable().Where(p => p.Title.ToLower().Contains(title.ToLower()))
                                         .Include(c => c.Comments)
                                         .Include(c => c.User)
                                         .Where(p => (bool)!p.IsDeleted)
                                         .ToListAsync();

            List<PostWithUserDTO> result = new List<PostWithUserDTO>();
            foreach(var post in results)
            {
                PostWithUserDTO postWithUserDTO = new PostWithUserDTO 
                { 
                    Id = post.Id,
                    UserId = post.UserId,
                    Username = post.User.LastName,
                    Avatar = post.User.Avatar,
                    Title = post.Title,
                    Content = post.Content,
                    LikeQuantity = post.LikeQuantity,
                    CreatedDate = post.CreationDate
                };
                result.Add(postWithUserDTO);
            }
            return result;
        }

        public async Task<IEnumerable<PostWithUserDTO>> GetAllPostWithUsernameAndAvatar()
        {
            return await _dbContext.Posts.Include(p => p.User)
                                         .Where(p => (bool)!p.IsDeleted)
                                         .Select(p => new PostWithUserDTO
                                         {
                                             Id = p.Id,
                                             UserId = p.UserId,
                                             Username = p.User.LastName,
                                             Avatar = p.User.Avatar,
                                             Title = p.Title,
                                             Content = p.Content,
                                             LikeQuantity = p.LikeQuantity,
                                             CreatedDate = p.CreationDate
                                         })
                                         .ToListAsync() ;
        }
    }
}
