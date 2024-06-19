using Application.ViewModels.ShipCompanyDTOs;
using FluentValidation;

namespace EXE_02.Validations.ShipCompanyValidations
{
    public class ShipCompanyUpdateDTOValidation : AbstractValidator<UpdateShipCompanyDTO>
    {
        public ShipCompanyUpdateDTOValidation() {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name cannot be empty.")
                    .MinimumLength(2).WithMessage("Name must be at least 2 characters long.");
        }
    }
}
