using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.AddressToShipDTOs;
using Application.ViewModels.FeedBackDTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FeedBackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<FeedBackViewDTO>> CreateAFeedBackAsync(FeedBackCreateDTO createDTO)
        {
            ServiceResponse<FeedBackViewDTO> reponse = new ServiceResponse<FeedBackViewDTO>();
            try
            {
                var Entity = _mapper.Map<Feedback>(createDTO);
                await _unitOfWork.FeedBackRepository.AddAsync(Entity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Success = true;
                    reponse.Message = "Create new FeedBack successfully";
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

        public async Task<ServiceResponse<FeedBackViewDTO>> DeleteFeedBackAsync(int id)
        {
            var reponse = new ServiceResponse<FeedBackViewDTO>();
            try
            {
                var entity = await _unitOfWork.FeedBackRepository.GetByIdAsync(id);

                if (entity == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found feedback, you are sure input";
                    reponse.Error = "feedback is Null";
                }
                else
                {
                    if (entity.IsDeleted == true)
                    {
                        reponse.Data = _mapper.Map<FeedBackViewDTO>(entity);
                        reponse.Success = false;
                        reponse.Message = "feedback is deleted, cant delete again.";
                        reponse.Error = "Is Deleted";
                    }
                    else
                    {
                        _unitOfWork.FeedBackRepository.SoftRemove(entity);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            var entityAfterDeleted = await _unitOfWork.FeedBackRepository.GetByIdAsync(id, x => x.User);
                            var mapper = _mapper.Map<FeedBackViewDTO>(entityAfterDeleted);
                            mapper.UserName = entity.User.FirstName + entity.User.LastName;
                            reponse.Data = mapper;
                            reponse.Success = true;
                            reponse.Message = "deleted feedback successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update feedback fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update feedback fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedBackAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<FeedBackViewDTO>>();
            try
            {
                var c = await _unitOfWork.FeedBackRepository.GetAllAsync(x => x.User);
                List<FeedBackViewDTO> ListDTO = new List<FeedBackViewDTO>();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any feedback";
                }
                else
                {
                    foreach (var cc in c)
                    {
                        if (cc.IsDeleted != true)
                        {
                            var mapper = _mapper.Map<FeedBackViewDTO>(cc);
                            mapper.UserName = cc.User.FirstName + cc.User.LastName;
                            ListDTO.Add(mapper);
                        }
                    }

                    reponse.Data = ListDTO;
                    reponse.Success = true;
                    reponse.Message = "feedback Retrieved Successfully";
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

        public async Task<ServiceResponse<FeedBackViewDTO>> GetFeedBackByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<FeedBackViewDTO>();
            try
            {
                var c = await _unitOfWork.FeedBackRepository.GetByIdAsync(Id, x => x.User);
                if (c == null || c.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any FeedBack";
                }
                else
                {
                    var mapper = _mapper.Map<FeedBackViewDTO>(c);
                    mapper.UserName = c.User.FirstName + c.User.LastName;
                    reponse.Data = mapper;
                    reponse.Success = true;
                    reponse.Message = "FeedBack Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedBackByUserIDAsync(int userID)
        {
            var reponse = new ServiceResponse<IEnumerable<FeedBackViewDTO>>();
            try
            {
                List<FeedBackViewDTO> ListDTO = new List<FeedBackViewDTO>();
                var c = await _unitOfWork.FeedBackRepository.GetAllAsync(x => x.User);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any FeedBack";
                }
                else
                {
                    var s = c.Where(x => x.IsDeleted == false || x.IsDeleted == null && x.UserId == userID).ToList();
                    foreach (var cc in s)
                    {
                        var mapper = _mapper.Map<FeedBackViewDTO>(cc);
                        mapper.UserName = cc.User.FirstName + cc.User.LastName;
                        ListDTO.Add(mapper);
                    }

                    reponse.Data = ListDTO;
                    reponse.Success = true;
                    reponse.Message = "FeedBack Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedBackInProduct(int pID)
        {
            var reponse = new ServiceResponse<IEnumerable<FeedBackViewDTO>>();
            try
            {
                List<FeedBackViewDTO> ListDTO = new List<FeedBackViewDTO>();
                var c = await _unitOfWork.FeedBackRepository.GetAllAsync(x => x.User);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any FeedBack";
                }
                else
                {
                    var s = c.Where(x => x.IsDeleted == false && x.ProductId == pID).ToList();
                    foreach (var cc in s)
                    {
                        var mapper = _mapper.Map<FeedBackViewDTO>(cc);
                        mapper.UserName = cc.User.FirstName + cc.User.LastName;
                        ListDTO.Add(mapper);
                    }

                    reponse.Data = ListDTO;
                    reponse.Success = true;
                    reponse.Message = "FeedBack Retrieved Successfully";
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

        public async Task<ServiceResponse<FeedBackViewDTO>> UpdateFeedBackAsync(int id, FeedBackUpdateDTO updateDTO)
        {
            var reponse = new ServiceResponse<FeedBackViewDTO>();
            try
            {
                var sChecked = await _unitOfWork.FeedBackRepository.GetByIdAsync(id, x => x.User);

                if (sChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found FeedBack, you are sure input, please checked FeedBack";
                    reponse.Error = "Not found FeedBack";
                }
                else if (sChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "FeedBack is deleted, cant deleted this object";
                    reponse.Error = "This FeedBack is deleted";
                }
                else
                {

                    var spFofUpdate = _mapper.Map(updateDTO, sChecked);
                    var spDTOAfterUpdate = _mapper.Map<FeedBackViewDTO>(spFofUpdate);
                    spDTOAfterUpdate.UserName = spFofUpdate.User.FirstName + spFofUpdate.User.LastName;
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = spDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Message = "Update FeedBack successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update FeedBack fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update FeedBack fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }
    }
}
