using FluentValidation;
using MediatR;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>, IRequest<int>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(entityCommand =>
                entityCommand.Name).NotEmpty().Must(cat => cat.Any(char.IsLetter)).MaximumLength(250);
        }
    }
}
