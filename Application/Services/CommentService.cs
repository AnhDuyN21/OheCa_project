using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.CommentDTOs;
using Application.ViewModels.UserDTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;

        }
        public async Task<ServiceResponse<IEnumerable<CommentDTO>>> GetCommnetByPostId(int postId)
        {
            var response = new ServiceResponse<IEnumerable<CommentDTO>>();
            try
            {
                var getAllComment = await _unitOfWork.CommentRepository.GetAllAsync();
                var newListComment = new List<CommentDTO>();
                foreach (var comment in getAllComment)
                {
                    if (comment.PostId == postId)
                    {
                        newListComment.Add(_mapper.Map<CommentDTO>(comment));
                    }
                }
                if (newListComment.Count != 0)
                {
                    response.Success = true;
                    response.Message = "List comment retrieved successfully";
                    response.Data = newListComment;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Not have commnet in this post";
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
        public async Task<ServiceResponse<CommentDTO>> CreateCommentAsync(int postId, CreateCommentDTO createCommentDTO)
        {
            var response = new ServiceResponse<CommentDTO>();
            var checkPostId = await _unitOfWork.PostRepository.GetByIdAsync(postId);
            if (checkPostId == null)
            {
                response.Success = true;
                response.Message = "Post không tồn tại";
                return response;
            }
            try
            {
                var comment = _mapper.Map<Comment>(createCommentDTO);
                comment.PostId = postId;
                comment.UserId = _claimsService.GetUserId();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };

            }
            return response;

        }
        public async Task<ServiceResponse<bool>>DeleteCommentAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var comment = _unitOfWork.CommentRepository.GetByIdAsync(id);
                if(comment == null)
                {
                    response.Success = false;
                    response.Message = "Comment ID không tồn tại";
                }
                
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }
            return response;
        }
    }
}
