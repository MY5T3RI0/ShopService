using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IRepoService<Product> _service;

        public CreateProductCommandHandler(IRepoService<Product> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var product = new Product
            {
                CategoryId = request.CategoryId,
                ManufacturerId = request.ManufacturerId,
                Name = request.Name,
                Price = request.Price,
                PriceChanges = new List<PriceChange>(),
                ChangesDetails = new List<ChangesDetails>(),
                ImageName = request.ImageName,
            };

            await _service.AddAsync(product);

            return product.Id;
        }
    }
}
