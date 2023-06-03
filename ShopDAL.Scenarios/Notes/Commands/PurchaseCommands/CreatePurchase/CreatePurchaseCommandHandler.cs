using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, int>
    {
        private readonly IRepoService<Purchase> _service;

        public CreatePurchaseCommandHandler(IRepoService<Purchase> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));
        public async Task<int> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = new Purchase
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                StoreProducts = request.StoreProducts,
                CustomerId = request.CustomerId
            };

            await _service.AddAsync(entity);

            entity.StoreProducts.Select(x => x.PurchaseId = entity.Id);

            await _service.UpdateAsync(entity);

            return entity.Id;
        }
    }
}
