using Application.Interfaces;
using Application.Services;
using Application.ViewModels.PostDTOs;
using Application.ViewModels.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    [Authorize]
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPostList()
        {
            var postList = await _postService.GetAllPostAsync();
            return Ok(postList);
        } 
        [HttpGet]
        public async Task<IActionResult> GetPostByUser()
        {
            var postList = await _postService.GetPostByUserIdAsync();
            return Ok(postList);
        }
        [HttpGet("{title}")]
        public async Task<IActionResult> SearchPostByTitle(string title)
        {
            var result = await _postService.SearchPostByTitleAsync(title);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByPostId(int id)
        {
            var postList = await _postService.GetPostByPostIdAsync(id);
            if (postList.Success)
            {
                return Ok(postList);
            }
            else
            {
                return BadRequest(postList);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostDTO createPostDTO)
        {
                var response = await _postService.CreatePostAsync(createPostDTO);
                if (response.Success)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromForm] UpdatePostDTO updatePostDTO)
        {
            var postToUpdate = await _postService.UpdatePostAsync(id, updatePostDTO);
            if (!postToUpdate.Success)
            {
                return NotFound(postToUpdate);
            }
            return Ok(postToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var deletedPost = await _postService.DeletePostAsync(id);
            if (!deletedPost.Success)
            {
                return NotFound(deletedPost);
            }

            return Ok(deletedPost);
        }
        [HttpGet]
        public async Task<IActionResult> LikePost(int postId)
        {
            var result = await _postService.LikePostAsync(postId);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
