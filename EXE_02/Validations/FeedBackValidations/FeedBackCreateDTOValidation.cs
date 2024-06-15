using Application.ViewModels.FeedBackDTOs;
using FluentValidation;
namespace EXE_02.Validations.FeedBackValidations
{
    public class FeedBackCreateDTOValidation : AbstractValidator<FeedBackCreateDTO>
    {
        public FeedBackCreateDTOValidation()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty.")
                .MinimumLength(2).WithMessage("Content must be at least 2 characters long.");
            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("Rate cannot be empty.")
                .InclusiveBetween(1, 5).WithMessage("Rate must be between 1 and 5.");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.");
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId cannot be empty.");

        }
    }
}
