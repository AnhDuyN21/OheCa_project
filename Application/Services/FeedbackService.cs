using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.AddressToShipDTOs;
using Application.ViewModels.FeedBackDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FeedBackViewDTO>> CreateFeedbackAsync(FeedBackCreateDTO createDTO)
        {
            ServiceResponse<FeedBackViewDTO> reponse = new ServiceResponse<FeedBackViewDTO>();
            try
            {
                var Entity = _mapper.Map<Feedback>(createDTO);
                Entity.IsDeleted = false;
                await _unitOfWork.FeedbackRepository.AddAsync(Entity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<FeedBackViewDTO>(Entity);
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

        public async Task<ServiceResponse<FeedBackViewDTO>> DeleteFeedbackAsync(int id)
        {
            var reponse = new ServiceResponse<FeedBackViewDTO>();
            try
            {
                var entity = await _unitOfWork.FeedbackRepository.GetByIdAsync(id);

                if (entity == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found FeedBack, you are sure input";
                    reponse.Error = "FeedBack is Null";
                }
                else
                {
                    if (entity.IsDeleted == true)
                    {
                        reponse.Data = _mapper.Map<FeedBackViewDTO>(entity);
                        reponse.Success = false;
                        reponse.Message = "FeedBack is deleted, cant delete again.";
                        reponse.Error = "Is Deleted";
                    }
                    else
                    {
                        _unitOfWork.FeedbackRepository.SoftRemove(entity);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            var entityAfterDeleted = await _unitOfWork.FeedbackRepository.GetByIdAsync(id);
                            reponse.Data = _mapper.Map<FeedBackViewDTO>(entityAfterDeleted);
                            reponse.Success = true;
                            reponse.Message = "deleted FeedBack successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update FeedBack fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Deleted FeedBack fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedbackAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<FeedBackViewDTO>>();
            List<FeedBackViewDTO> dtos = new List<FeedBackViewDTO>();
            try
            {
                var c = await _unitOfWork.FeedbackRepository.GetAllAsync(x => x.User);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any FeedBack";
                }
                else
                {
                    if (c.Count <= 0)
                    {
                        reponse.Success = true;
                        reponse.Message = "FeedBack Retrieved Successfully, But List is empty , please add new.";
                    }
                    else
                    {
                        foreach (var item in c)
                        {
                             var mapper = _mapper.Map<FeedBackViewDTO>(item);
                            mapper.UserName = item.User.FirstName + " " +item.User.LastName;
                            dtos.Add(mapper);
                        }
                        reponse.Data = dtos;
                        reponse.Success = true;
                        reponse.Message = "FeedBack Retrieved Successfully";
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

        public async Task<ServiceResponse<FeedBackViewDTO>> GetFeedbackByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<FeedBackViewDTO>();
            try
            {
                var c = await _unitOfWork.FeedbackRepository.GetByIdAsync(Id, x => x.User);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any FeedBack";
                }
                else
                {
                    var mapper = _mapper.Map<FeedBackViewDTO>(c);
                    mapper.UserName = c.User.FirstName + " " + c.User.LastName;
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

        public async Task<ServiceResponse<IEnumerable<FeedBackViewDTO>>> GetFeedbackByUserIDAsync(int userID)
        {
            var reponse = new ServiceResponse<IEnumerable<FeedBackViewDTO>>();
            List<FeedBackViewDTO> dtos = new List<FeedBackViewDTO>();
            try
            {
                var c = await _unitOfWork.FeedbackRepository.GetAllAsync(x => x.User);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any FeedBack";
                }
                else
                {
                    var s = c.Where(x => x.IsDeleted == false &&  x.UserId == userID);
                    foreach (var item in s)
                    {
                        var mapper = _mapper.Map<FeedBackViewDTO>(item);
                        mapper.UserName = item.User.FirstName + " " + item.User.LastName;
                        dtos.Add(mapper);
                    }
                    reponse.Data = dtos;
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

        public async Task<ServiceResponse<FeedBackViewDTO>> UpdateFeedbackAsync(int id, FeedBackUpdateDTO updateDTO)
        {
            var reponse = new ServiceResponse<FeedBackViewDTO>();
            try
            {
                var sChecked = await _unitOfWork.FeedbackRepository.GetByIdAsync(id);

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
