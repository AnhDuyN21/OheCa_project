
﻿using Application.ViewModels.VoucherDTOs;
using FluentValidation;

namespace EXE_02.Validations.VoucherValidations
{
    public class VoucherUpdateDTOValidation : AbstractValidator<UpdateVoucherDTO>
    {
        public VoucherUpdateDTOValidation()
        {
            RuleFor(x => x.Discount)
                    .NotNull().WithMessage("Discount cannot be null.")
                    .InclusiveBetween(0, 100).WithMessage("Discount must be between 0 and 1.");

            //RuleFor(x => x.StartTime)
            //    .NotNull().WithMessage("StartTime cannot be null.")
            //    .GreaterThanOrEqualTo(DateTime.Today).WithMessage("StartTime must be today or in the future.");

            //RuleFor(x => x.EndTime)
            //    .NotNull().WithMessage("EndTime cannot be null.")
            //    .GreaterThanOrEqualTo(x => x.StartTime).WithMessage("EndTime must be after StartTime.")
            //    .When(x => x.EndTime.HasValue && x.StartTime.HasValue);

            RuleFor(x => x.TotalQuantityVoucher)
                .NotNull().WithMessage("TotalQuantityVoucher cannot be null.")
                .GreaterThan(0).WithMessage("TotalQuantityVoucher must be greater than 0.");

            RuleFor(x => x.UsedQuanity)
                .NotNull().WithMessage("UsedQuantity cannot be null.")
                .GreaterThanOrEqualTo(0).WithMessage("UsedQuantity must be greater than or equal to 0.");
        }
    }
}
