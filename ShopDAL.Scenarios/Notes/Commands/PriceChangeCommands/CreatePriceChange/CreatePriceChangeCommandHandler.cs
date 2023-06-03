using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreatePriceChangeCommandHandler : IRequestHandler<CreatePriceChangeCommand, int>
    {
        private readonly IRepoService<PriceChange> _service;
        private readonly IRepoService<Product> _serviceProduct;

        public CreatePriceChangeCommandHandler(IRepoService<PriceChange> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));
        public async Task<int> Handle(CreatePriceChangeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = new PriceChange
            {
                DateOfChange = DateOnly.FromDateTime(DateTime.Now),
                ChangesDetails = request.ChangeDetails
            };

            await _service.AddAsync(entity);

            entity.ChangesDetails.Select(x => x.PriceChangesId = entity.Id);

            await _service.UpdateAsync(entity);

            return entity.Id;
        }
    }
}
