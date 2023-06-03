using FluentValidation;
using MediatR;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>, IRequest<int>
    {
        public CreatePurchaseCommandValidator()
        {
            RuleFor(entityCommand => entityCommand.CustomerId).GreaterThanOrEqualTo(0);
            RuleFor(entityCommand => entityCommand.StoreProducts).NotEmpty().Must(BeAValidStoreProducts);
        }

        private bool BeAValidStoreProducts(List<StoreProducts> storeProducts)
        {
            bool result;
            foreach (var storeProduct in storeProducts)
            {
                result = storeProduct.StoreId >= 0 ? true : false;
                foreach (var product in storeProduct.PurchaseDetails)
                {
                    result = product.ProductId >= 0 && result ? true : false;
                    result = product.ProductCount > 0 && result ? true : false;
                    result = product.Discount >= 0 && result ? true : false;

                    if (!result) return false;
                }
            }
            return true;
        }

    }
}
