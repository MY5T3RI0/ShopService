

using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductPriceCommandValidator : AbstractValidator<UpdateProductPriceCommand>, IRequest
    {
        public UpdateProductPriceCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
