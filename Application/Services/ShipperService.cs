using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.ShipCompanyDTOs;
using Application.ViewModels.ShipperDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class ShipperService : IShipperService
    {
     
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ShipperService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShipperViewDTO>> CreateShipperAsync(CreateShipperDTO createDTO)
        {
            ServiceResponse<ShipperViewDTO> reponse = new ServiceResponse<ShipperViewDTO>();
            try
            {
                var shipperEntity = _mapper.Map<Shipper>(createDTO);
                await _unitOfWork.ShipperRepository.AddAsync(shipperEntity);
                shipperEntity.IsDeleted = false;
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<ShipperViewDTO>(shipperEntity);
                    reponse.Success = true;
                    reponse.Message = "Create new shipper successfully";
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

        public async Task<ServiceResponse<ShipperViewDTO>> DeleteShipperAsync(int id)
        {
            var reponse = new ServiceResponse<ShipperViewDTO>();
            try
            {
                var Shipper = await _unitOfWork.ShipperRepository.GetByIdAsync(id);

                if (Shipper == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found shipper, you are sure input";
                    reponse.Error = "shipper is Null";
                }
                else
                {
                    if (Shipper.IsDeleted == true)
                    {
                        reponse.Data = _mapper.Map<ShipperViewDTO>(Shipper);
                        reponse.Success = false;
                        reponse.Message = "Shipper is deleted, cant delete again.";
                        reponse.Error = "Is Deleted";
                    }
                    else
                    {
                        _unitOfWork.ShipperRepository.SoftRemove(Shipper);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            var shipperAfterDeleted = await _unitOfWork.ShipCompanyRepository.GetByIdAsync(id);
                            reponse.Data = _mapper.Map<ShipperViewDTO>(shipperAfterDeleted);
                            reponse.Success = true;
                            reponse.Message = "deleted Shipper successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update Shipper fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update Shipper fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<ShipperViewDTO>> GetShipperByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<ShipperViewDTO>();
            try
            {
                var c = await _unitOfWork.ShipperRepository.GetByIdAsync(Id);
                if (c == null || c.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Shipper";
                }
                else
                {
                    reponse.Data = _mapper.Map<ShipperViewDTO>(c);
                    reponse.Success = true;
                    reponse.Message = "Shipper Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ShipperViewDTO>>> GetShippersAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ShipperViewDTO>>();
            List<ShipperViewDTO> ListDTO = new List<ShipperViewDTO>();
            try
            {
                var c = await _unitOfWork.ShipperRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Shipper";
                }
                else
                {
                    foreach (var cc in c)
                    {
                        if (cc.IsDeleted != true)
                        {
                            var mapper = _mapper.Map<ShipperViewDTO>(cc);
                            ListDTO.Add(mapper);
                        }
                    }
                    reponse.Data = ListDTO;
                    reponse.Success = true;
                    reponse.Message = "Shipper Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ShipperViewDTO>>> GetShippersByCompanyAsync(int companyId)
        {
            var reponse = new ServiceResponse<IEnumerable<ShipperViewDTO>>();
            List<ShipperViewDTO> ListDTO = new List<ShipperViewDTO>();
            try
            {
                var c = await _unitOfWork.ShipperRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Shipper";
                }
                else
                {
                    foreach (var cc in c)
                    {
                        if (cc.IsDeleted != true && cc.ShipCompanyId == companyId)
                        {
                            var mapper = _mapper.Map<ShipperViewDTO>(c);
                            ListDTO.Add(mapper);
                        }
                    }
                    if (ListDTO.Count <= 0)
                    {
                        reponse.Success = false;
                        reponse.Message = "Don't Have Any Shipper";
                    }
                    else
                    {
                        reponse.Data = ListDTO;
                        reponse.Success = true;
                        reponse.Message = "Shipper Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ShipperViewDTO>>> GetSortedShippersAsync(string sortName)
        {
            var response = new ServiceResponse<IEnumerable<ShipperViewDTO>>();
            try
            {
                var shippers = await _unitOfWork.ShipperRepository.GetAllAsync();
                if (shippers == null || !shippers.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any Shippers";
                    return response;
                }

                var filteredshipper = shippers.Where(x => x.IsDeleted == false);
                if (!filteredshipper.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any Shippers";
                    return response;
                }

                IEnumerable<Shipper> sortedShippers;
                switch (sortName)
                {
                    case "A-Z":
                        sortedShippers = filteredshipper.OrderBy(x => x.Name);
                        break;
                    case "Z-A":
                        sortedShippers = filteredshipper.OrderByDescending(x => x.Name);
                        break;
                    case "New":
                        sortedShippers = filteredshipper.OrderByDescending(x => x.Id);
                        break;
                    case "Old":
                        sortedShippers = filteredshipper.OrderBy(x => x.Id);
                        break;
                    default:
                        sortedShippers = filteredshipper;
                        break;
                }

                response.Data = _mapper.Map<IEnumerable<ShipperViewDTO>>(sortedShippers);
                response.Success = true;
                response.Message = "Shipper Retrieved Successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while retrieving Shipper.";
                response.ErrorMessages = new List<string> { ex.Message };
                if (ex.InnerException != null)
                {
                    response.ErrorMessages.Add(ex.InnerException.Message);
                }
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ShipperViewDTO>>> searchShippersByNameAsync(string name)
        {
            var reponse = new ServiceResponse<IEnumerable<ShipperViewDTO>>();
            try
            {
                var c = await _unitOfWork.ShipperRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Shipper";
                }
                else
                {
                    var s = c.Where(x => x.Name.ToLower().Contains(name.ToLower()) && x.IsDeleted != true).ToList();
                    if (s.Count <= 0 || s == null)
                    {
                        reponse.Success = false;
                        reponse.Message = "Don't Have Any Shipper";
                    }
                    else
                    {
                        reponse.Data = _mapper.Map<IEnumerable<ShipperViewDTO>>(s);
                        reponse.Success = true;
                        reponse.Message = "Shipper Retrieved Successfully";
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

        public async Task<ServiceResponse<ShipperViewDTO>> UpdateShippperAsync(int id, UpdateShipperDTO updateDTO)
        {
            var reponse = new ServiceResponse<ShipperViewDTO>();
            try
            {
                var sChecked = await _unitOfWork.ShipperRepository.GetByIdAsync(id);

                if (sChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found shipper, you are sure input, please checked shipper";
                    reponse.Error = "Not found shipper";
                }
                else if (sChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "shipper is deleted, cant deleted this object";
                    reponse.Error = "This shipper is deleted";
                }
                else
                {

                    var spFofUpdate = _mapper.Map(updateDTO, sChecked);
                    var spDTOAfterUpdate = _mapper.Map<ShipperViewDTO>(spFofUpdate);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = spDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Message = "Update shipper successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update shipper fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update shipper fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }
    }
}
