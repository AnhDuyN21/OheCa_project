using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.PaymentDTOs;
using Application.ViewModels.ShipCompanyDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class ShipCompanyService : IShipCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ShipCompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShipCompanyViewDTO>> CreateShipCompanyAsync(CreateShipCompanyDTO createDTO)
        {
            ServiceResponse<ShipCompanyViewDTO> reponse = new ServiceResponse<ShipCompanyViewDTO>();
            try
            {
                var shipCompanyEntity = _mapper.Map<ShipCompany>(createDTO);
                await _unitOfWork.ShipCompanyRepository.AddAsync(shipCompanyEntity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<ShipCompanyViewDTO>(shipCompanyEntity);
                    reponse.Success = true;
                    reponse.Message = "Create new ship company successfully";
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

        public async Task<ServiceResponse<ShipCompanyViewDTO>> DeleteShipCompanyAsync(int id)
        {
            var reponse = new ServiceResponse<ShipCompanyViewDTO>();
            try
            {
                var ShipCompany = await _unitOfWork.ShipCompanyRepository.GetByIdAsync(id);

                if (ShipCompany == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found ShipCompany, you are sure input";
                    reponse.Error = "ShipCompany is Null";
                }
                else
                {
                    if (ShipCompany.IsDeleted == true)
                    {
                        reponse.Data = _mapper.Map<ShipCompanyViewDTO>(ShipCompany);
                        reponse.Success = false;
                        reponse.Message = "ShipCompany is deleted, cant delete again.";
                        reponse.Error = "Is Deleted";
                    }
                    else
                    {
                        _unitOfWork.ShipCompanyRepository.SoftRemove(ShipCompany);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            var shipCompanyDetail = await _unitOfWork.ShipCompanyRepository.GetByIdAsync(id);
                            reponse.Data = _mapper.Map<ShipCompanyViewDTO>(shipCompanyDetail);
                            reponse.Success = true;
                            reponse.Message = "deleted ShipCompany successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update ShipCompany fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update ShipCompany fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<ShipCompanyViewDTO>> GetShipCompanyByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<ShipCompanyViewDTO>();
            try
            {
                var c = await _unitOfWork.ShipCompanyRepository.GetByIdAsync(Id);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any ShipCompany";
                }
                else
                {
                    reponse.Data = _mapper.Map<ShipCompanyViewDTO>(c);
                    reponse.Success = true;
                    reponse.Message = "ShipCompany Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ShipCompanyViewDTO>>> GetShipCompanysAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ShipCompanyViewDTO>>();
            try
            {
                var c = await _unitOfWork.ShipCompanyRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any ShipCompany";
                }
                else
                {
                    reponse.Data = _mapper.Map<IEnumerable<ShipCompanyViewDTO>>(c);
                    reponse.Success = true;
                    reponse.Message = "ShipCompany Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ShipCompanyViewDTO>>> GetSortedShipCompanysAsync(string sortName)
        {
            var response = new ServiceResponse<IEnumerable<ShipCompanyViewDTO>>();
            try
            {
                var shipcompanys = await _unitOfWork.ShipCompanyRepository.GetAllAsync();
                if (shipcompanys == null || !shipcompanys.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any ShipCompany";
                    return response;
                }

                var filteredshipcompanys = shipcompanys.Where(x => x.IsDeleted == false);
                if (!filteredshipcompanys.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any ShipCompany";
                    return response;
                }

                IEnumerable<ShipCompany> sortedShipCompanys;
                switch (sortName)
                {
                    case "A-Z":
                        sortedShipCompanys = filteredshipcompanys.OrderBy(x => x.Name);
                        break;
                    case "Z-A":
                        sortedShipCompanys = filteredshipcompanys.OrderByDescending(x => x.Name);
                        break;
                    case "New":
                        sortedShipCompanys = filteredshipcompanys.OrderByDescending(x => x.Id);
                        break;
                    case "Old":
                        sortedShipCompanys = filteredshipcompanys.OrderBy(x => x.Id);
                        break;
                    default:
                        sortedShipCompanys = filteredshipcompanys;
                        break;
                }

                response.Data = _mapper.Map<IEnumerable<ShipCompanyViewDTO>>(sortedShipCompanys);
                response.Success = true;
                response.Message = "ShipCompany Retrieved Successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while retrieving ShipCompany.";
                response.ErrorMessages = new List<string> { ex.Message };
                if (ex.InnerException != null)
                {
                    response.ErrorMessages.Add(ex.InnerException.Message);
                }
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ShipCompanyViewDTO>>> searchShipCompanyByNameAsync(string name)
        {
            var reponse = new ServiceResponse<IEnumerable<ShipCompanyViewDTO>>();
            try
            {
                var c = await _unitOfWork.ShipCompanyRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any ShipCompany";
                }
                else
                {
                    var s = c.Where(x => x.Name.ToLower().Contains(name.ToLower()) && x.IsDeleted == false).ToList();
                    if (s.Count <= 0 || s == null)
                    {
                        reponse.Success = false;
                        reponse.Message = "Don't Have Any ShipCompany";
                    }
                    else
                    {
                        reponse.Data = _mapper.Map<IEnumerable<ShipCompanyViewDTO>>(s);
                        reponse.Success = true;
                        reponse.Message = "ShipCompany Retrieved Successfully";
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

        public async Task<ServiceResponse<ShipCompanyViewDTO>> UpdateShipCompanyAsync(int id, UpdateShipCompanyDTO updateDTO)
        {
            var reponse = new ServiceResponse<ShipCompanyViewDTO>();
            try
            {
                var scChecked = await _unitOfWork.ShipCompanyRepository.GetByIdAsync(id);

                if (scChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found ship company, you are sure input, please checked company";
                    reponse.Error = "Not found company";
                }
                else if (scChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "company is deleted, cant dleted this object";
                    reponse.Error = "This company detail is deleted";
                }
                else
                {

                    var spFofUpdate = _mapper.Map(updateDTO, scChecked);
                    var spDTOAfterUpdate = _mapper.Map<ShipCompanyViewDTO>(spFofUpdate);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = spDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Message = "Update company successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update company fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update company fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }
    }
}
