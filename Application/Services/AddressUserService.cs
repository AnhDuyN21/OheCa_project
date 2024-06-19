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
    }
}
