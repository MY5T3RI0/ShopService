
using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>, IRequest<int>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(entityCommand => entityCommand.ManufacturerId).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.Price).InclusiveBetween(1, 9999999);
            RuleFor(entityCommand => entityCommand.CategoryId).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.ImageName).NotEmpty().MaximumLength(250);
        }

    }
}
