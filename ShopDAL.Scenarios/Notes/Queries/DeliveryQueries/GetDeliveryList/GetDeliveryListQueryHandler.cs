using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class GetDeliveriesListQueryHandler : IRequestHandler<GetDeliveriesListQuery, DeliveryListVm>
    {
        private readonly IRepoService<Delivery> _service;
        private readonly IMapper _mapper;

        public GetDeliveriesListQueryHandler(IRepoService<Delivery> service,
            IMapper mapper)
        {
            if (service is null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (mapper is null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            (_service, _mapper) = (service, mapper);
        }

        public async Task<DeliveryListVm> Handle(GetDeliveriesListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var deliveries = await _service.GetAllAsync();

            if (deliveries == null)
                throw new NotFoundException(nameof(Delivery), request);

            var deliveriesQuery = deliveries.Select(_mapper.Map<DeliveryLookupDto>).ToList();

            return new DeliveryListVm { Deliveries = deliveriesQuery };
        }
    }
}
