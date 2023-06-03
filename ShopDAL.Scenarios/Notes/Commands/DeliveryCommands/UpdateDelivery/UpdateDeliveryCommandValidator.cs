using FluentValidation;
using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateDeliveryCommandValidator : AbstractValidator<UpdateDeliveryCommand>, IRequest
    {
        public UpdateDeliveryCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.Date).InclusiveBetween(DateOnly.FromDateTime(DateTime.Now.AddYears(-100)), DateOnly.FromDateTime(DateTime.Now));
            RuleFor(entityCommand => entityCommand.StoreId).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.DeliveryInfos).Must(BeAValidDeliveryInfo).NotEmpty();
        }

        private bool BeAValidDeliveryInfo(List<DeliveryInfo> deliveryInfos)
        {
            bool result;
            foreach (var deliveryInfo in deliveryInfos)
            {
                result = deliveryInfo.ProductId >= 0 ? true : false;
                result = deliveryInfo.ProductCount >= 0 && result ? true : false;

                if (!result) return false;
            }
            return true;
        }
    }
}
