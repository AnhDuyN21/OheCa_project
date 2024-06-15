using Application.ViewModels.OrderDetailDTOs;
using FluentValidation;

namespace EXE_02.Validations.OrderDetailValidations
{
    public class OrderDetailCreateDTOValidatio : AbstractValidator<UpdateOrderDetailDTO>
    {
        public OrderDetailCreateDTOValidatio() 
        {
            RuleFor(x => x.ProductId)
                    .GreaterThan(0).WithMessage("ProductId must be a positive integer.")
                    .When(x => x.ProductId.HasValue);

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be a positive integer.")
                .When(x => x.Quantity.HasValue);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be a positive number.")
                .When(x => x.Price.HasValue);
        }
    }
}
