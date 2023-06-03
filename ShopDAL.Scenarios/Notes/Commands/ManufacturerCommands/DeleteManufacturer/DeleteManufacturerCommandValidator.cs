using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteManufacturerCommandValidator : AbstractValidator<DeleteManufacturerCommand>, IRequest
    {
        public DeleteManufacturerCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
        }
    }
}
