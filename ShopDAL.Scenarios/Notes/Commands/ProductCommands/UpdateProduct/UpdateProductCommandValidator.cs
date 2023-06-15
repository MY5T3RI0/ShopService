
using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>, IRequest
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Name).NotEmpty();
            RuleFor(entityCommand => entityCommand.ImageName).NotEmpty();
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.ManufacturerId).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.CategoryId).GreaterThanOrEqualTo(0);
        }
    }
}
