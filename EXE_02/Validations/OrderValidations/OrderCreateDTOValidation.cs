
using Application.ViewModels.OrderDTOs;
using FluentValidation;


namespace EXE_02.Validations.OrderValidations
{
    public class OrderCreateDTOValidation : AbstractValidator<CreateOrderDTO>
    {
        public OrderCreateDTOValidation() 
            {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("UserId cannot be null.");

            RuleFor(x => x.ShipperId)
                .NotNull().WithMessage("ShipperId cannot be null.");

            RuleFor(x => x.OrderDate)
                .NotNull().WithMessage("OrderDate cannot be null.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("OrderDate cannot be in the future.");

            RuleFor(x => x.ShipDate)
                .GreaterThanOrEqualTo(x => x.OrderDate).WithMessage("ShipDate must be after OrderDate.")
                .When(x => x.ShipDate.HasValue && x.OrderDate.HasValue);

            RuleFor(x => x.ReceiveDate)
                .GreaterThanOrEqualTo(x => x.ShipDate).WithMessage("ReceiveDate must be after ShipDate.")
                .When(x => x.ReceiveDate.HasValue && x.ShipDate.HasValue);

            RuleFor(x => x.FreightCost)
                .NotNull().WithMessage("FreightCost cannot be null.")
                .GreaterThanOrEqualTo(0).WithMessage("FreightCost must be a positive number.");

            RuleFor(x => x.IsConfirm)
                .NotNull().WithMessage("IsConfirm cannot be null.")
                .InclusiveBetween(0, 1).WithMessage("IsConfirm must be either 0 or 1.");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("Status cannot be null.");

            RuleFor(x => x.PaymentId)
                .NotNull().WithMessage("PaymentId cannot be null.");

            RuleFor(x => x.StatusOfPayment)
                .NotNull().WithMessage("StatusOfPayment cannot be null.")
                .InclusiveBetween(0, 1).WithMessage("StatusOfPayment must be either 0 or 1.");

            RuleFor(x => x.AddressToShipId)
                .NotNull().WithMessage("AddressToShipId cannot be null.");

            RuleFor(x => x.TotalPrice)
                .NotNull().WithMessage("TotalPrice cannot be null.")
                .GreaterThanOrEqualTo(0).WithMessage("TotalPrice must be a positive number.");
        }
    }
}
