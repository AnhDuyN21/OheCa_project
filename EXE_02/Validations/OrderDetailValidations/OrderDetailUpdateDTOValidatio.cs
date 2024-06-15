using Application.ViewModels.OrderDetailDTOs;
using FluentValidation;

namespace EXE_02.Validations.OrderDetailValidations
{
    public class OrderDetailUpdateDTOValidatio : AbstractValidator<CreateOrderDetailDTO>
    {
        public OrderDetailUpdateDTOValidatio() 
        {
            RuleFor(x => x.OrderId)
                    .NotNull().WithMessage("OrderId cannot be null.")
                    .GreaterThan(0).WithMessage("OrderId must be a positive integer.");

            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("ProductId cannot be null.")
                .GreaterThan(0).WithMessage("ProductId must be a positive integer.");

            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Quantity cannot be null.")
                .GreaterThan(0).WithMessage("Quantity must be a positive integer.");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Price cannot be null.")
                .GreaterThan(0).WithMessage("Price must be a positive number.");
        }
    }
}
