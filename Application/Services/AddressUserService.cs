using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.AddressToShipDTOs;
using Application.ViewModels.AddressUserDTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AddressUserService : IAddressUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddressUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ViewAddressUserDTO>> CreateAddressUserAsync(CreateAddressUserDTO createDTO)
        {
            ServiceResponse<ViewAddressUserDTO> reponse = new ServiceResponse<ViewAddressUserDTO>();
            try
            {
                var addressUsersList = await _unitOfWork.AddressUserRepository.GetAllAsync(x => x.AddressToShip);
                //var adexited = AddressUsers.Where(x => x.AddressToShipId == createDTO.AddressToShipId).First();
                //if (adexited != null)
                //{
                //    reponse.Data = _mapper.Map<ViewAddressUserDTO>(adexited);
                //    reponse.Success = false;
                //    reponse.Message = $"Create new AddressUser Fail,Address is exits by user have id {adexited.UserId}, Please choose another addresstoship for user.";
                //}
                //else
                //{
                //    var Entity = _mapper.Map<AddressUser>(createDTO);
                //    await _unitOfWork.AddressUserRepository.AddAsync(Entity);
                //    if (await _unitOfWork.SaveChangeAsync() > 0)
                //    {
                //        reponse.Data = _mapper.Map<ViewAddressUserDTO>(Entity);
                //        reponse.Success = true;
                //        reponse.Message = "Create new AddressToShip successfully";
                //    }
                //}

                foreach (var addressUser in addressUsersList)
                {
                    if (createDTO.AddressToShipId == addressUser.AddressToShip.Id)
                    {
                        reponse.Success = false;
                        reponse.Message = $"Address belong to User id {addressUser.UserId}";
                        return reponse;
                    }
                }
                var addressToShip = await _unitOfWork.AddressToShipRepository.GetByIdAsync((int)createDTO.AddressToShipId);
                if (addressToShip == null)
                {
                    reponse.Success = false;
                    reponse.Message = $"Address with id {createDTO.AddressToShipId} is not exist";
                    return reponse;
                }
                var Entity = _mapper.Map<AddressUser>(createDTO);
                await _unitOfWork.AddressUserRepository.AddAsync(Entity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<ViewAddressUserDTO>(Entity);
                    reponse.Success = true;
                    reponse.Message = "Create new AddressToShip successfully";
                }


            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Message = ex.Message;
                reponse.ErrorMessages = new List<string> { ex.InnerException.ToString() };
            }
            return reponse;
        }

        public async Task<ServiceResponse<ViewAddressUserDTO>> DeleteAddressUserAsync(int id)
        {
            var reponse = new ServiceResponse<ViewAddressUserDTO>();
            try
            {
                var entity = await _unitOfWork.AddressUserRepository.GetByIdAsync(id);

                if (entity == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found AddressUser, you are sure input";
                    reponse.Error = "AddressUser is Null";
                }
                else
                {
                    if (entity.IsDeleted == true)
                    {
                        reponse.Success = false;
                        reponse.Message = "AddressUser is deleted, cant delete again.";
                        reponse.Error = "Is Deleted";
                    }
                    else
                    {
                        _unitOfWork.AddressUserRepository.SoftRemove(entity);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Success = true;
                            reponse.Message = "deleted AddressUser successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update AddressUser fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update AddressUser fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<ViewAddressUserDTO>> UpdateAddressUserAsync(int id, UpdateAddressUserDTO updateDTO)
        {
            var reponse = new ServiceResponse<ViewAddressUserDTO>();
            try
            {
                var sChecked = await _unitOfWork.AddressUserRepository.GetByIdAsync(id);

                if (sChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found AddressUser, you are sure input, please checked AddressUser";
                    reponse.Error = "Not found AddressUser";
                }
                else if (sChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "AddressUser is deleted, cant deleted this object";
                    reponse.Error = "This AddressUser is deleted";
                }
                else
                {

                    var spFofUpdate = _mapper.Map(updateDTO, sChecked);
                    var spDTOAfterUpdate = _mapper.Map<ViewAddressUserDTO>(spFofUpdate);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = spDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Message = "Update AddressUser successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update AddressUser fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update AddressUser fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<ViewAddressUserDTO>>> ViewAll()
        {
            var reponse = new ServiceResponse<IEnumerable<ViewAddressUserDTO>>();
            try
            {
                var c = await _unitOfWork.AddressUserRepository.GetAllAsync(x => x.User, x => x.AddressToShip);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any AddressUser";
                }
                else
                {
                    if (c.Count <= 0)
                    {
                        reponse.Success = true;
                        reponse.Message = "AddressUser Retrieved Successfully, But List is empty , please add new.";
                    }
                    else
                    {
                        reponse.Data = _mapper.Map<IEnumerable<ViewAddressUserDTO>>(c);
                        reponse.Success = true;
                        reponse.Message = "AddressUser Retrieved Successfully";
                    }

                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Message = ex.Message;
                reponse.ErrorMessages = new List<string> { ex.InnerException.ToString() };
            }
            return reponse;
        }
    }
}
