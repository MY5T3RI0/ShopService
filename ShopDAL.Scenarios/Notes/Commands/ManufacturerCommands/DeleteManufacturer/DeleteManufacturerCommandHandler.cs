using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.DeleteProduct
{
    public class DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand>
    {
        private readonly IRepoService<Manufacturer> _service;

        public DeleteManufacturerCommandHandler(IRepoService<Manufacturer> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Manufacturer), request.Id);

            await _service.DeleteAsync(entity);
        }
    }
}
