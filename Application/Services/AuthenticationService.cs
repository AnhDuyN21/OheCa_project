using Application.Commons;
using Application.Interfaces;
using Application.ServiceResponse;
using Application.Utils;
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
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;

        //private IValidator<Account> _validator;
        private readonly IMapper _mapper;

        public AuthenticationService(
        IUnitOfWork unitOfWork,
        ICurrentTime currentTime,
        AppConfiguration configuration,
        IMapper mapper
)
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> LoginAsync(AuthenUserDTO usertDTO)
        {
            var response = new ServiceResponse<string>();
            var user = await _unitOfWork.UserRepository.GetUserByEmailAndPassword(usertDTO.Email, usertDTO.Password);
            try
            {
                if(user == null)
                {
                    response.Success = false;
                    response.Message = "Invalid username or password";
                    return response;
                }
                if (user.ConfirmToken != null)
                {
                    //System.Console.WriteLine(user.ConfirmationToken + user.IsConfirmed);
                    response.Success = false;
                    response.Message = "Please confirm via link in your mail";
                    return response;
                }
                var token = user.GenerateJsonWebToken(
                    _configuration,
                    _configuration.JWTSection.SecretKey,
                    _currentTime.GetCurrentTime()
                    );

                response.Success = true;
                response.Message = "Login successfully.";
                response.Data = token;
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

        public async Task<ServiceResponse<UserDTO>> RegisterAsync(RegisterUserDTO registerUserDTO)
        {
            var response = new ServiceResponse<UserDTO>();
            try
            {
                var exist = await _unitOfWork.UserRepository.CheckEmailNameExited(registerUserDTO.Email);
                if (exist)
                {
                    response.Success = false;
                    response.Message = "Email is existed";
                    return response;
                }
                var user = _mapper.Map<User>(registerUserDTO);
                // Tạo token ngẫu nhiên
                user.ConfirmToken = Guid.NewGuid().ToString();
                user.Status = 1;
                user.RoleId = 1;
                await _unitOfWork.UserRepository.AddAsync(user);
                var confirmationLink = $"https://localhost:5001/swagger/confirm?token={user.ConfirmToken}";
                // Gửi email xác nhận
                var emailSent = await SendEmail.SendConfirmationEmail(user.Email, confirmationLink);
                if (!emailSent)
                {
                    // Xử lý khi gửi email không thành công
                    response.Success = false;
                    response.Message = "Error sending confirmation email.";
                    return response;
                }
                else
                {
                    var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if (isSuccess)
                    {
                        var userDTO = _mapper.Map<UserDTO>(user);
                        response.Data = userDTO; // Chuyển đổi sang UserDTO
                        response.Success = true;
                        response.Message = "Register successfully.";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Error saving the account.";
                    }
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
    }
}
