using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateManufacturerCommandValidator : AbstractValidator<UpdateManufacturerCommand>, IRequest
    {
        public UpdateManufacturerCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
