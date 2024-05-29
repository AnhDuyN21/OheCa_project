using Application.ViewModels.UserDTO;
using FluentValidation;

namespace EXE_02.Validations.UserValidations
{
    public class RegisterAccountViewModelValidation : AbstractValidator<RegisterUserDTO>
    {
        public RegisterAccountViewModelValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(email => email.EndsWith("@gmail.com"))
                .WithMessage("Email must have the extension @gmail.com");
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^0[0-9]{9}$")
                .WithMessage("The phone number must have 10 digits and start with 0");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long");
        }
    }
}
