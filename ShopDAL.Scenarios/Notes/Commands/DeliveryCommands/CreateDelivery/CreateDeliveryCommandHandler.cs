using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;

namespace ShopDAL.Scenarios.Notes.Commands.ProductCommands.CreateProduct
{
    public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, int>
    {
        private readonly IRepoService<Delivery> _service;

        public CreateDeliveryCommandHandler(IRepoService<Delivery> service) =>
            _service = service ?? throw new ArgumentNullException(nameof(service));
        public async Task<int> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var delivery = new Delivery
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                StoreId = request.StoreId,
                DeliveryInfos = request.DeliveryInfos
            };

            await _service.AddAsync(delivery);

            delivery.DeliveryInfos.Select(x => x.DeliveryId = delivery.Id);

            await _service.UpdateAsync(delivery);

            return delivery.Id;
        }
    }
}
