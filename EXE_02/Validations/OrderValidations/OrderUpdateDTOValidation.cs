using Application.ViewModels.OrderDTOs;
using FluentValidation;

namespace EXE_02.Validations.OrderValidations
{
    public class OrderUpdateDTOValidation : AbstractValidator<UpdateOrderDTO>
    {
        public OrderUpdateDTOValidation() 
        {
            RuleFor(x => x.Id)
                    .GreaterThan(0).WithMessage("Id must be a positive integer.");

            RuleFor(x => x.ShipperId)
                .GreaterThan(0).WithMessage("ShipperId must be a positive integer.")
                .When(x => x.ShipperId.HasValue);

            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("OrderDate cannot be in the future.")
                .When(x => x.OrderDate.HasValue);

            RuleFor(x => x.ShipDate)
                .GreaterThanOrEqualTo(x => x.OrderDate).WithMessage("ShipDate must be after OrderDate.")
                .When(x => x.ShipDate.HasValue && x.OrderDate.HasValue);

            RuleFor(x => x.ReceiveDate)
                .GreaterThanOrEqualTo(x => x.ShipDate).WithMessage("ReceiveDate must be after ShipDate.")
                .When(x => x.ReceiveDate.HasValue && x.ShipDate.HasValue);

            RuleFor(x => x.FreightCost)
                .GreaterThanOrEqualTo(0).WithMessage("FreightCost must be a positive number.")
                .When(x => x.FreightCost.HasValue);

            RuleFor(x => x.IsConfirm)
                .InclusiveBetween(0, 1).WithMessage("IsConfirm must be either 0 or 1.")
                .When(x => x.IsConfirm.HasValue);

            RuleFor(x => x.Status)
                .GreaterThan(0).WithMessage("Status must be a positive integer.")
                .When(x => x.Status.HasValue);

            RuleFor(x => x.PaymentId)
                .GreaterThan(0).WithMessage("PaymentId must be a positive integer.")
                .When(x => x.PaymentId.HasValue);

            RuleFor(x => x.StatusOfPayment)
                .InclusiveBetween(0, 1).WithMessage("StatusOfPayment must be either 0 or 1.")
                .When(x => x.StatusOfPayment.HasValue);

            RuleFor(x => x.AddressToShipId)
                .GreaterThan(0).WithMessage("AddressToShipId must be a positive integer.")
                .When(x => x.AddressToShipId.HasValue);

            RuleFor(x => x.TotalPrice)
                .GreaterThanOrEqualTo(0).WithMessage("TotalPrice must be a positive number.")
                .When(x => x.TotalPrice.HasValue);
        }
    }
}
