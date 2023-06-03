using FluentValidation;
using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateDeliveryCommandValidator : AbstractValidator<CreateDeliveryCommand>, IRequest<int>
    {
        public CreateDeliveryCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.StoreId).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.DeliveryInfos).NotEmpty().Must(BeAValidDeliveryInfo);
        }
        private bool BeAValidDeliveryInfo(List<DeliveryInfo> deliveryInfos)
        {
            bool result; 
            foreach(var deliveryInfo in deliveryInfos)
            {
                result = deliveryInfo.ProductId >= 0 ? true : false;
                result = deliveryInfo.ProductCount >= 0 && result ? true : false;

                if (!result) return false;
            }
            return true;
        }
    }
}
