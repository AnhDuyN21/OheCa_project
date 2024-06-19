using Application.ViewModels.PaymentDTOs;
using FluentValidation;

namespace EXE_02.Validations.PaymentValidations
{
    public class PaymentUpdateDTOValidation : AbstractValidator<UpdatePaymentDTO>
    {
        public PaymentUpdateDTOValidation() 
        {
            RuleFor(x => x.Method)
                    .NotEmpty().WithMessage("Method cannot be empty.")
                    .MinimumLength(2).WithMessage("Method must be at least 2 characters long.");
        }
    }
}
