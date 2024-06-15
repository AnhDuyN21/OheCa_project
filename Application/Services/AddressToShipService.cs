using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.AddressToShipDTOs;
using AutoMapper;
using Domain.Entities;


namespace Application.Services
{
    public class AddressToShipService : IAddressToShipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddressToShipService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ViewAddressToShipDTO>> CreateAddressToShipAsync(CreateAddressToShipDTO createDTO)
        {
            ServiceResponse<ViewAddressToShipDTO> reponse = new ServiceResponse<ViewAddressToShipDTO>();
            try
            {
                var Entity = _mapper.Map<AddressToShip>(createDTO);
                await _unitOfWork.AddressToShipRepository.AddAsync(Entity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<ViewAddressToShipDTO>(Entity);
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

        public async Task<ServiceResponse<ViewAddressToShipDTO>> DeleteAddressToShipAsync(int id)
        {
            var reponse = new ServiceResponse<ViewAddressToShipDTO>();
            try
            {
                var entity = await _unitOfWork.AddressToShipRepository.GetByIdAsync(id);

                if (entity == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found AddressToShip, you are sure input";
                    reponse.Error = "AddressToShip is Null";
                }
                else
                {
                    if (entity.IsDeleted == true)
                    {
                        reponse.Data = _mapper.Map<ViewAddressToShipDTO>(entity);
                        reponse.Success = false;
                        reponse.Message = "AddressToShip is deleted, cant delete again.";
                        reponse.Error = "Is Deleted";
                    }
                    else
                    {
                        _unitOfWork.AddressToShipRepository.SoftRemove(entity);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            var entityAfterDeleted = await _unitOfWork.AddressToShipRepository.GetByIdAsync(id);
                            reponse.Data = _mapper.Map<ViewAddressToShipDTO>(entityAfterDeleted);
                            reponse.Success = true;
                            reponse.Message = "deleted AddressToShip successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update AddressToShip fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update AddressToShip fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<ViewAddressToShipDTO>>> GetAddressToShipAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ViewAddressToShipDTO>>();
            try
            {
                var c = await _unitOfWork.AddressToShipRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any AddressToShip";
                }
                else
                {
                    if(c.Count <= 0)
                    {
                        reponse.Success = true;
                        reponse.Message = "AddressToShip Retrieved Successfully, But List is empty , please add new.";
                    }
                    else
                    {
                        reponse.Data = _mapper.Map<IEnumerable<ViewAddressToShipDTO>>(c);
                        reponse.Success = true;
                        reponse.Message = "AddressToShip Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ViewAddressToShipDTO>>> GetAddressToShipByUserIDAsync(int userID)
        {
            var reponse = new ServiceResponse<IEnumerable<ViewAddressToShipDTO>>();
            try
            {
                var c = await _unitOfWork.AddressToShipRepository.GetAllAsync(x => x.AddressUsers);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Address to Ship";
                }
                else
                {
                    var s = c.Where(x => x.IsDeleted == false && x.AddressUsers.Select(x => x.UserId == userID).First()).ToList();
                    reponse.Data = _mapper.Map<IEnumerable<ViewAddressToShipDTO>>(s);
                    reponse.Success = true;
                    reponse.Message = "Address to Ship Retrieved Successfully";
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

        public async Task<ServiceResponse<ViewAddressToShipDTO>> GetAddressToShipByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<ViewAddressToShipDTO>();
            try
            {
                var c = await _unitOfWork.AddressToShipRepository.GetByIdAsync(Id);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Address To Ship";
                }
                else
                {
                    reponse.Data = _mapper.Map<ViewAddressToShipDTO>(c);
                    reponse.Success = true;
                    reponse.Message = "Address To Ship Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ViewAddressToShipDTO>>> GetSortedAddressToShipsAsync(string sortName)
        {
            var response = new ServiceResponse<IEnumerable<ViewAddressToShipDTO>>();
            try
            {
                var entitys = await _unitOfWork.AddressToShipRepository.GetAllAsync();
                if (entitys == null || !entitys.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any Address To Ship";
                    return response;
                }

                var filteredentitys = entitys.Where(x => x.IsDeleted == false);
                if (!filteredentitys.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any Address To Ship";
                    return response;
                }

                IEnumerable<AddressToShip> sortedentitys;
                switch (sortName)
                {
                    case "A-Z":
                        sortedentitys = filteredentitys.OrderBy(x => x.Ward);
                        break;
                    case "Z-A":
                        sortedentitys = filteredentitys.OrderByDescending(x => x.Ward);
                        break;
                    case "New":
                        sortedentitys = filteredentitys.OrderByDescending(x => x.CreationDate);
                        break;
                    case "Old":
                        sortedentitys = filteredentitys.OrderBy(x => x.CreationDate);
                        break;
                    default:
                        sortedentitys = filteredentitys;
                        break;
                }

                response.Data = _mapper.Map<IEnumerable<ViewAddressToShipDTO>>(sortedentitys);
                response.Success = true;
                response.Message = "Address To Ship Retrieved Successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while retrieving Address To Ship.";
                response.ErrorMessages = new List<string> { ex.Message };
                if (ex.InnerException != null)
                {
                    response.ErrorMessages.Add(ex.InnerException.Message);
                }
            }
            return response;
        }

        public Task<ServiceResponse<IEnumerable<ViewAddressToShipDTO>>> searchAddressToShipsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<ViewAddressToShipDTO>> UpdateAddressToShipAsync(int id, UpdateAddressToShipDTO updateDTO)
        {
            var reponse = new ServiceResponse<ViewAddressToShipDTO>();
            try
            {
                var sChecked = await _unitOfWork.AddressToShipRepository.GetByIdAsync(id);

                if (sChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found AddressToShip, you are sure input, please checked AddressToShip";
                    reponse.Error = "Not found AddressToShip";
                }
                else if (sChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "AddressToShip is deleted, cant deleted this object";
                    reponse.Error = "This AddressToShip is deleted";
                }
                else
                {

                    var spFofUpdate = _mapper.Map(updateDTO, sChecked);
                    var spDTOAfterUpdate = _mapper.Map<ViewAddressToShipDTO>(spFofUpdate);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = spDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Message = "Update AddressToShip successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update AddressToShip fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update AddressToShip fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }
    }
}
