using FluentValidation;
using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>, IRequest<int>
    {
        public CreateStoreCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Name).NotEmpty();
        }
    }
}
