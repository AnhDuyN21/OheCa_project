using Application.ViewModels.AddressToShipDTOs;
using Application.ViewModels.FeedBackDTOs;
using FluentValidation;

namespace EXE_02.Validations.AddressToShipValidations
{
    public class AddressToShipUpdateDTOValidation : AbstractValidator<UpdateAddressToShipDTO>
    {
        public AddressToShipUpdateDTOValidation()
        {
            RuleFor(x => x.Province)
                .MinimumLength(2).WithMessage("Province must be at least 2 characters long.")
                .When(x => !string.IsNullOrEmpty(x.Province));

            RuleFor(x => x.District)
                .MinimumLength(2).WithMessage("District must be at least 2 characters long.")
                .When(x => !string.IsNullOrEmpty(x.District));

            RuleFor(x => x.Ward)
                .MinimumLength(2).WithMessage("Ward must be at least 2 characters long.")
                .When(x => !string.IsNullOrEmpty(x.Ward));

            RuleFor(x => x.DetailAddress)
                .MinimumLength(2).WithMessage("Detail Address must be at least 2 characters long.")
                .When(x => !string.IsNullOrEmpty(x.DetailAddress));

            RuleFor(x => x.Phone)
                .Matches(@"^0\d{9}$").WithMessage("Phone number must be exactly 10 digits and start with '0'.")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer Name cannot be empty.")
                .MinimumLength(2).WithMessage("Customer Name must be at least 2 characters long.");

        }
    }
}
