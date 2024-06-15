using Application.ViewModels.ShipperDTOs;
using FluentValidation;

namespace EXE_02.Validations.ShipperValidations
{
    public class ShipperCreateDTOValidation : AbstractValidator<CreateShipperDTO>
    {
        public ShipperCreateDTOValidation() 
        {
            RuleFor(x => x.ShipCompanyId)
                    .NotNull().WithMessage("ShipCompanyId cannot be null.")
                    .GreaterThan(0).WithMessage("ShipCompanyId must be a positive integer.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone cannot be empty.")
                .Matches(@"^(\+\d{1,3}[- ]?)?\d{10}$").WithMessage("Phone number format is not valid.")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.");
        }
    }
}
