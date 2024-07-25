
﻿using Application.Interfaces;
using Application.ServiceResponse;
using Application.ViewModels.ShipperDTOs;
using Application.ViewModels.VoucherDTOs;
using AutoMapper;
using Domain.Entities;
using MailKit.Search;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.Design;


namespace Application.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VoucherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ViewVoucherDTO>> CreateVoucherAsync(CreateVoucherDTO createDTO)
        {
            ServiceResponse<ViewVoucherDTO> reponse = new ServiceResponse<ViewVoucherDTO>();
            try
            {
                var Entity = _mapper.Map<Voucher>(createDTO);
                await _unitOfWork.VoucherRepository.AddAsync(Entity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<ViewVoucherDTO>(Entity);
                    reponse.Success = true;
                    reponse.Message = "Create new voucher successfully";
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

        public async Task<ServiceResponse<ViewVoucherDTO>> DeleteVoucherAsync(int id)
        {
            var reponse = new ServiceResponse<ViewVoucherDTO>();
            try
            {
                var entity = await _unitOfWork.VoucherRepository.GetByIdAsync(id);

                if (entity == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found voucher, you are sure input";
                    reponse.Error = "voucher is Null";
                }
                else
                {
                    if (entity.IsDeleted == true)
                    {
                        reponse.Data = _mapper.Map<ViewVoucherDTO>(entity);
                        reponse.Success = false;
                        reponse.Message = "voucher is deleted, cant delete again.";
                        reponse.Error = "Is Deleted";
                    }
                    else
                    {
                        _unitOfWork.VoucherRepository.SoftRemove(entity);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            var entityAfterDeleted = await _unitOfWork.VoucherRepository.GetByIdAsync(id);
                            reponse.Data = _mapper.Map<ViewVoucherDTO>(entityAfterDeleted);
                            reponse.Success = true;
                            reponse.Message = "deleted voucher successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Delete voucher fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Delete voucher fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> GetSortedVouchersAsync(string sortName)
        {
            var response = new ServiceResponse<IEnumerable<ViewVoucherDTO>>();
            try
            {
                var entitys = await _unitOfWork.VoucherRepository.GetAllAsync();
                if (entitys == null || !entitys.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any voucher";
                    return response;
                }

                var filteredentitys = entitys.Where(x => x.IsDeleted == false);
                if (!filteredentitys.Any())
                {
                    response.Success = false;
                    response.Message = "Don't Have Any voucher";
                    return response;
                }

                IEnumerable<Voucher> sortedVouchers;
                switch (sortName)
                {
                    case "A-Z":
                        sortedVouchers = filteredentitys.OrderBy(x => x.Discount);
                        break;
                    case "Z-A":
                        sortedVouchers = filteredentitys.OrderByDescending(x => x.Discount);
                        break;
                    case "New":
                        sortedVouchers = filteredentitys.OrderByDescending(x => x.CreationDate);
                        break;
                    case "Old":
                        sortedVouchers = filteredentitys.OrderBy(x => x.CreationDate);
                        break;
                    default:
                        sortedVouchers = filteredentitys;
                        break;
                }

                response.Data = _mapper.Map<IEnumerable<ViewVoucherDTO>>(sortedVouchers);
                response.Success = true;
                response.Message = "Voucher Retrieved Successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while retrieving voucher.";
                response.ErrorMessages = new List<string> { ex.Message };
                if (ex.InnerException != null)
                {
                    response.ErrorMessages.Add(ex.InnerException.Message);
                }
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> GetVoucherAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ViewVoucherDTO>>();
            List<ViewVoucherDTO> ListDTO = new List<ViewVoucherDTO>();
            try
            {
                var c = await _unitOfWork.VoucherRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Voucher";
                }
                else
                {
                    foreach (var cc in c)
                    {
                        if (cc.IsDeleted != true)
                        {
                            var mapper = _mapper.Map<ViewVoucherDTO>(cc);
                            ListDTO.Add(mapper);
                        }
                    }
                    reponse.Data = ListDTO;
                    reponse.Success = true;
                    reponse.Message = "Voucher Retrieved Successfully";
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

        public async Task<ServiceResponse<ViewVoucherDTO>> GetVoucherByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<ViewVoucherDTO>();
            try
            {
                var c = await _unitOfWork.VoucherRepository.GetByIdAsync(Id);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Voucher";
                }
                else
                {
                    reponse.Data = _mapper.Map<ViewVoucherDTO>(c);
                    reponse.Success = true;
                    reponse.Message = "Voucher Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> GetVoucherIsUsedByOrderByUserIDAsync(int orderId)
        {
            var reponse = new ServiceResponse<IEnumerable<ViewVoucherDTO>>();
            try
            {
                var c = await _unitOfWork.VoucherRepository.GetAllAsync(x => x.VoucherUsages);
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Voucher";
                }
                else
                {
                    var s = c.Where(x => x.IsDeleted != true && x.VoucherUsages.Any(x => x.OrderId == orderId)).ToList();
                    reponse.Data = _mapper.Map<IEnumerable<ViewVoucherDTO>>(c);
                    reponse.Success = true;
                    reponse.Message = "Voucher Retrieved Successfully";
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

        public bool ValidateVoucher(Voucher v)
        {
            bool flag = true;
            if (v.IsDeleted == false)
            {
                return flag = false;
            }
            if (v.UsedQuanity >= (v.TotalQuantityVoucher - 0))
            {
                return flag = false;
            }
            if(v.EndTime.HasValue && v.EndTime.Value.TimeOfDay <= DateTime.UtcNow.TimeOfDay)
            {
                return flag = false;
            }
            return flag;
        }
        public async Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> GetVoucherIsValidAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ViewVoucherDTO>>();
            try
            {
                var c = await _unitOfWork.VoucherRepository.GetAllAsync();
                if (c == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Don't Have Any Voucher";
                }
                else
                {
                    List<Voucher> s = new List<Voucher>();
                    foreach(var cc in c)
                    {
                        if (ValidateVoucher(cc)) 
                        {
                            s.Add(cc);
                        }
                    }
                    reponse.Data = _mapper.Map<IEnumerable<ViewVoucherDTO>>(s);
                    reponse.Success = true;
                    reponse.Message = "Voucher Is Valid Retrieved Successfully";
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

        public async Task<ServiceResponse<ViewVoucherDTO>> UpdateVoucherAsync(int id, UpdateVoucherDTO updateDTO)
        {
            var reponse = new ServiceResponse<ViewVoucherDTO>();
            try
            {
                var sChecked = await _unitOfWork.VoucherRepository.GetByIdAsync(id);

                if (sChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found voucher, you are sure input, please checked voucher";
                    reponse.Error = "Not found voucher";
                }
                else if (sChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "voucher is deleted, cant update this object";
                    reponse.Error = "This voucher is deleted";
                }
                else
                {

                    var spFofUpdate = _mapper.Map(updateDTO, sChecked);
                    var spDTOAfterUpdate = _mapper.Map<ViewVoucherDTO>(spFofUpdate);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = spDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Message = "Update voucher successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Message = "Update voucher fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update voucher fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<ViewVoucherDTO>>> AddVoucherForOrderAsync(List<CreateVoucherUsageDTO> createDTOs)
        {
            var response = new ServiceResponse<IEnumerable<ViewVoucherDTO>>();
            try
            {
                var voucherValids = new List<CreateVoucherUsageDTO>();
                var voucherNotValid = new List<CreateVoucherUsageDTO>();

                foreach (var item in createDTOs)
                {
                    var existingVoucherUsages = await _unitOfWork.VoucherUsageRepository.GetAllAsync();

                    var existingVoucherUsage =  existingVoucherUsages.FirstOrDefault(vu => vu.VoucherId == item.VoucherId && vu.OrderId == item.OrderId);

                    if (existingVoucherUsage != null)
                    {
                        response.Data = null;
                        response.Success = false;
                        response.Message = "Voucher already exists for this order. Please choose another voucher.";
                        return response;
                    }

                    var voucher = await _unitOfWork.VoucherRepository.GetByIdAsync((int)item.VoucherId);
                    if (voucher != null && ValidateVoucher(voucher))
                    {
                        voucherValids.Add(item);
                    }
                    else if (voucher != null && !ValidateVoucher(voucher))
                    {
                        voucherNotValid.Add(item);
                    }
                }

                if (voucherNotValid.Count > 0)
                {
                    response.Data = _mapper.Map<IEnumerable<ViewVoucherDTO>>(voucherNotValid);
                    response.Success = false;
                    response.Message = "Voucher is not valid, please choose another voucher";
                    return response;
                }

                var entityList = _mapper.Map<List<Voucher>>(voucherValids);
                await _unitOfWork.VoucherRepository.AddRangeAsync(entityList);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    response.Data = _mapper.Map<IEnumerable<ViewVoucherDTO>>(entityList);
                    response.Success = true;
                    response.Message = "Create new voucher successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failed to create new vouchers";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.ErrorMessages = new List<string> { ex.InnerException?.ToString() ?? ex.Message };
            }
            return response;
        }



    }
}

