using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct
{
    public class UpdatePriceChangeCommandHandler : IRequestHandler<UpdatePriceChangeCommand, int>
    {
        private readonly IRepoService<PriceChange> _service;

        public UpdatePriceChangeCommandHandler(IRepoService<PriceChange> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));

        public async Task<int> Handle(UpdatePriceChangeCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(PriceChange), request.Id);

            entity.DateOfChange = request.Date;
            entity.ChangesDetails = request.ChangesDetails;

            var newEntity = new PriceChange
            {
                DateOfChange = entity.DateOfChange,
                ChangesDetails = entity.ChangesDetails
            };

            await _service.DeleteAsync(entity);
            await _service.AddAsync(newEntity);

            return newEntity.Id;
        }
    }
}
