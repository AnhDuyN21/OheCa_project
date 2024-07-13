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
                    if (comment.PostId == postId && comment.IsDeleted == false)
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
                    response.Message = "Not have commnet in this post or post have been deleted";
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

            #region Check validation

            var checkPostId = await _unitOfWork.PostRepository.GetByIdAsync(postId);
            if (checkPostId == null || checkPostId.IsDeleted == true)
            {
                response.Success = true;
                response.Message = "Post not exist";
                return response;
            }

            #endregion

            try
            {
                var comment = _mapper.Map<Comment>(createCommentDTO);
                comment.PostId = postId;
                comment.UserId = _claimsService.GetUserId();
                comment.IsDeleted = false;

                await _unitOfWork.CommentRepository.AddAsync(comment);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess)
                {
                    var commentDTO = _mapper.Map<CommentDTO>(comment);
                    response.Data = commentDTO; 
                    response.Success = true;
                    response.Message = "Comment created successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error saving comment.";
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
        public async Task<ServiceResponse<bool>>DeleteCommentAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                #region check validation
                //Check comment có tồn tại hay không
                var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);
                if(comment == null)
                {
                    response.Success = false;
                    response.Message = "Comment ID not exist";
                    return response;
                }
                //Check chủ sở hữu comment
                var getUser = _claimsService.GetUserId();
                if(comment.UserId !=  getUser)
                {
                    response.Success = false;
                    response.Message = "This is not your comment";
                    return response;
                }
                //Check comment isDelete 
                if(comment.IsDeleted == true)
                {
                    response.Success = false;
                    response.Message = "Comment have been deleted or post been deleted";
                    return response;
                }
                #endregion

                _unitOfWork.CommentRepository.SoftRemove(comment);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess)
                {
                    response.Success = true;
                    response.Message = "Comment deleted successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error deleting comment.";
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
