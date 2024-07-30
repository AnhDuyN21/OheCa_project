using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.CommentDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE_02.Controllers
{
    //[Authorize]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCommentByPostId(int postId)
        {
            var commentList = await _commentService.GetCommnetByPostId(postId);
            return Ok(commentList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCommentWithPostId(int postId, [FromForm] CreateCommentDTO createCommentDTO)
        {
            var comment = await _commentService.CreateCommentAsync(postId, createCommentDTO);
            return Ok(comment);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentService.DeleteCommentAsync(id);
            if (!comment.Success)
            {
                return NotFound(comment);
            }

            return Ok(comment);
        }
    }
}
