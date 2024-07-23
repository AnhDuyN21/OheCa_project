using Application.ViewModels.ShipCompanyDTOs;
using FluentValidation;

namespace EXE_02.Validations.ShipCompanyValidations
{
    public class ShipCompanyCreateDTOValidation : AbstractValidator<CreateShipCompanyDTO>
    {
        public ShipCompanyCreateDTOValidation() 
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name cannot be null.")
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.");

        }
    }
}
