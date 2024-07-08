using Application.Interfaces;
using Application.ServiceResponse;
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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFirebaseStorageService _firebaseStorageService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IFirebaseStorageService firebaseStorageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _firebaseStorageService = firebaseStorageService;
        }

        public async Task<ServiceResponse<UserDTO>> CreateAccountAsync(CreateUserDTO createdUserDTO)
        {

            var response = new ServiceResponse<UserDTO>();

            var exist = await _unitOfWork.UserRepository.CheckEmailNameExited(createdUserDTO.Email);
            var existed = await _unitOfWork.UserRepository.CheckPhoneNumberExited(createdUserDTO.Phone);

            if (exist)
            {
                response.Success = false;
                response.Message = "Email is existed";
                return response;
            }
            else if (existed)
            {
                response.Success = false;
                response.Message = "Phone is existed";
                return response;
            }
            try
            {
                var account = _mapper.Map<User>(createdUserDTO);
                //account.PasswordHash = Utils.HashPassword.HashWithSHA256(createdUserDTO.Password);

                account.Status = 1;
                account.IsDeleted = false;
                if (createdUserDTO.Avatar != null)
                {
                    var folderPath = $"User/{createdUserDTO.Email}";
                    var imageUrls = await _firebaseStorageService.UploadImageAsync(createdUserDTO.Avatar, folderPath);
                    account.Avatar = imageUrls;
                }

                await _unitOfWork.UserRepository.AddAsync(account);

                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess)
                {
                    var accountDTO = _mapper.Map<UserDTO>(account);
                    response.Data = accountDTO; // Chuyển đổi sang AccountDTO
                    response.Success = true;
                    response.Message = "User created successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error saving the user.";
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

        public async Task<ServiceResponse<bool>> DeleteUserAsync(int id)
        {
            var response = new ServiceResponse<bool>();

            var exist = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (exist == null)
            {
                response.Success = false;
                response.Message = "Account is not existed";
                return response;
            }

            try
            {
                _unitOfWork.UserRepository.SoftRemove(exist);
                exist.Status = 0;
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (isSuccess)
                {
                    response.Success = true;
                    response.Message = "Account deleted successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error deleting the account.";
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

        public async Task<ServiceResponse<IEnumerable<UserDTO>>> GetUserAsync()
        {
            var _response = new ServiceResponse<IEnumerable<UserDTO>>();
            try
            {
                var users = await _unitOfWork.UserRepository.GetAllAsync();

                var userDTOs = new List<UserDTO>();

                foreach (var user in users)
                {
                    if (user.Status == 1)
                    {
                        userDTOs.Add(_mapper.Map<UserDTO>(user));
                    }
                }

                if (userDTOs.Count != 0)
                {
                    _response.Success = true;
                    _response.Message = "Account retrieved successfully";
                    _response.Data = userDTOs;
                }
                else
                {
                    _response.Success = true;
                    _response.Message = "Not have Account";
                }

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = "Error";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

        public async Task<ServiceResponse<UserDTO>> GetUserByIdAsync(int id)
        {
            var response = new ServiceResponse<UserDTO>();

            var exist = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (exist == null)
            {
                response.Success = false;
                response.Message = "Account is not existed";
            }
            else
            {
                response.Success = true;
                response.Message = "Account found";
                response.Data = _mapper.Map<UserDTO>(exist);
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<UserDTO>>> SearchUserByNameAsync(string name)
        {
            var response = new ServiceResponse<IEnumerable<UserDTO>>();

            try
            {
                var users = await _unitOfWork.UserRepository.SearchAccountByNameAsync(name);

                var userDTOs = new List<UserDTO>();

                foreach (var acc in users)
                {
                    if (acc.IsDeleted == false)
                    {
                        userDTOs.Add(_mapper.Map<UserDTO>(acc));
                    }
                }

                if (userDTOs.Count != 0)
                {
                    response.Success = true;
                    response.Message = "Account retrieved successfully";
                    response.Data = userDTOs;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Not have Account";
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


        public async Task<ServiceResponse<UserDTO>> UpdateUserAsync(int id, UserDTO userDTO)
        {
            var response = new ServiceResponse<UserDTO>();

            try
            {
                var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(id);

                if (existingUser == null)
                {
                    response.Success = false;
                    response.Message = "Account not found.";
                    return response;
                }

                if (existingUser.IsDeleted == true)
                {
                    response.Success = false;
                    response.Message = "Account is deleted in system";
                    return response;
                }


                // Map accountDT0 => existingUser
                var updated = _mapper.Map(userDTO, existingUser);
                //updated.PasswordHash = Utils.HashPassword.HashWithSHA256(accountDTO.PasswordHash);

                _unitOfWork.UserRepository.Update(existingUser);

                var updatedUserDto = _mapper.Map<UserDTO>(updated);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (isSuccess)
                {
                    response.Data = updatedUserDto;
                    response.Success = true;
                    response.Message = "Account updated successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Error updating the account.";
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
    }
}
