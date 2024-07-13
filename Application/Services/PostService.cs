using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.PostDTOs;
using Application.ViewModels.UserDTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }
        public async Task<ServiceResponse<IEnumerable<PostDTO>>> GetAllPostAsync()
        {
            var response = new ServiceResponse<IEnumerable<PostDTO>>();
            try
            {
                var getAllPosts = await _unitOfWork.PostRepository.GetAllAsync();
                var newListPosts = new List<PostDTO>();
                foreach (var post in getAllPosts)
                {
                    if(post.IsDeleted == false)
                    {
                        newListPosts.Add(_mapper.Map<PostDTO>(post));
                    }
                }
                if (newListPosts.Count != 0)
                {
                    response.Success = true;
                    response.Message = "List post retrieved successfully";
                    response.Data = newListPosts;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Not have post";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }
            return response;
        }       
        public async Task<ServiceResponse<IEnumerable<PostDTO>>> SearchPostByTitleAsync(string title)
        {
            var response = new ServiceResponse<IEnumerable<PostDTO>>();
            try
            {
                var getPostByTitle = await _unitOfWork.PostRepository.SearchPostByTitleAsync(title);
                var newListPosts = new List<PostDTO>();
                foreach (var post in getPostByTitle)
                {
                    if(post.IsDeleted == false)
                    {
                        newListPosts.Add(_mapper.Map<PostDTO>(post));
                    }
                }
                if (newListPosts.Count != 0)
                {
                    response.Success = true;
                    response.Message = "List post retrieved successfully";
                    response.Data = newListPosts;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Not have post";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }
            return response;
        }
        public async Task<ServiceResponse<PostDTO>> GetPostByPostIdAsync(int id)
        {
            var response = new ServiceResponse<PostDTO>();
            var exist = await _unitOfWork.PostRepository.GetByIdAsync(id);
            if (exist == null || exist.IsDeleted == true)
            {
                response.Success = false;
                response.Message = "Post is not existed";
            }
            else
            {
                response.Success = true;
                response.Message = "Post found";
                response.Data = _mapper.Map<PostDTO>(exist);
            }

            return response;
        }
        public async Task<ServiceResponse<bool>> DeletePostAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            var exist = await _unitOfWork.PostRepository.GetByIdAsync(id);
            if (exist == null)
            {
                response.Success = false;
                response.Message = "Post is not existed";
                return response;
            }
            if (exist.UserId != _claimsService.GetUserId())
            {
                response.Success = false;
                response.Message = "You not have permission";
                return response;
            }
            try
            {
                _unitOfWork.PostRepository.SoftRemove(exist);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess)
                {
                    response.Success = true;
                    response.Message = "Post deleted successfully.";
                    //Xóa các comment ở trong post
                    var commentList = await _unitOfWork.CommentRepository.GetAllAsync();
                    foreach(var comment in commentList)
                    {
                        if(comment.PostId == exist.Id)
                        {
                            comment.IsDeleted = true;
                            await _unitOfWork.SaveChangeAsync();
                        }
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error deleting the post.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { ex.Message };
            }

            return response;
        }
        public async Task<ServiceResponse<PostDTO>> CreatePostAsync(CreatePostDTO createPostDTO)
        {
            var response = new ServiceResponse<PostDTO>();
            try
            {
                var newPost = _mapper.Map<Post>(createPostDTO);

                newPost.IsDeleted = false;
                newPost.LikeQuantity = 0;;
                newPost.UserId = _claimsService.GetUserId();

                await _unitOfWork.PostRepository.AddAsync(newPost);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess)
                {
                    var postData = _mapper.Map<PostDTO>(newPost);
                    response.Data = postData; 
                    response.Success = true;
                    response.Message = "Post created successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error saving post.";
                }
            }
            catch (DbException ex)
            {
                response.Success = false;
                response.Message = "Database error occurred.";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            return response;
        }
        public async Task<ServiceResponse<PostDTO>> UpdatePostAsync(int id, UpdatePostDTO updatePostDTO)
        {
            var response = new ServiceResponse<PostDTO>();
            try
            {
                var getPost = await _unitOfWork.PostRepository.GetByIdAsync(id);

                if (getPost == null)
                {
                    response.Success = false;
                    response.Message = "Post not found.";
                    return response;
                }

                if (getPost.IsDeleted == true)
                {
                    response.Success = false;
                    response.Message = "Post is deleted in system";
                    return response;
                }
                if(getPost.UserId != _claimsService.GetUserId())
                {
                    response.Success = false;
                    response.Message = "You not have permission";
                    return response;
                }

                if (updatePostDTO != null)
                {
                    if (updatePostDTO.Title != null)
                    {
                        getPost.Title = updatePostDTO.Title;
                    }
                    if (updatePostDTO.Content != null)
                    {
                        getPost.Content = updatePostDTO.Content;
                    }
                }
                _unitOfWork.PostRepository.Update(getPost);

                var updatedPost = _mapper.Map<PostDTO>(getPost);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (isSuccess)
                {
                    response.Data = updatedPost;
                    response.Success = true;
                    response.Message = "Post updated successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error updating post.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            return response;
        }
        public async Task<ServiceResponse<IEnumerable<PostDTO>>> GetPostByUserIdAsync()
        {
            var response = new ServiceResponse<IEnumerable<PostDTO>>();
            try
            {
                int userId = _claimsService.GetUserId();
                var newListPosts = new List<PostDTO>();
                var getAllPosts = await _unitOfWork.PostRepository.GetAllAsync();
                foreach (var post in getAllPosts)
                {
                    if (post.IsDeleted == false && post.UserId == userId)
                    {
                        newListPosts.Add(_mapper.Map<PostDTO>(post));
                    }
                }
                if (newListPosts.Count != 0)
                {
                    response.Success = true;
                    response.Message = "List post retrieved successfully";
                    response.Data = newListPosts;
                }
                else
                {
                    response.Success = true;
                    response.Message = "You dont have any post";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }


            return response;
        }

    }
}
