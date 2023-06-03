using FluentValidation;
using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductsInStoreCommandValidator : AbstractValidator<UpdateProductsInStoreCommand>, IRequest
    {
        public UpdateProductsInStoreCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.Id).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.ProductsToChange).Must(BeAValidPostcode).NotEmpty();
        }

        private bool BeAValidPostcode(IEnumerable<(int ProductId, int ProductCount)> productsToChange)
        {
            bool result;
            foreach(var product in productsToChange)
            {
                result = product.ProductId > 0 ? true : false;
                result = product.ProductCount > 0 && result ? true : false;
                if (!result) return false;
            }
            return true;
        }
    }
}
