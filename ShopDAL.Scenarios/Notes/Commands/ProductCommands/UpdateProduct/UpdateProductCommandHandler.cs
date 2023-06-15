using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepoService<Product> _service;

        public UpdateProductCommandHandler(IRepoService<Product> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Product), request.Id);

            entity.Name = request.Name;
            entity.Price = request.Price;
            entity.CategoryId = request.CategoryId;
            entity.ManufacturerId = request.ManufacturerId;
            entity.ImageName = request.ImageName;

            await _service.UpdateAsync(entity);
        }
    }
}
