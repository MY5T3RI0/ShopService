using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, int>
    {
        private readonly IRepoService<Manufacturer> _service;

        public CreateManufacturerCommandHandler(IRepoService<Manufacturer> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));
        public async Task<int> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = new Manufacturer
            {
                Name = request.Name
            };

            await _service.AddAsync(entity);

            return entity.Id;
        }
    }
}
