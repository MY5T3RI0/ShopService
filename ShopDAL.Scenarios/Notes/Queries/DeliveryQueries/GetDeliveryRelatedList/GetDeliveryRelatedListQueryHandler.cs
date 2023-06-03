using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList
{
    public class GetDeliveryRelatedListQueryHandler : IRequestHandler<GetDeliveryRelatedListQuery, DeliveryRelatedListVm>
    {
        private readonly IRepoService<Delivery> _service;
        private readonly IMapper _mapper;

        public GetDeliveryRelatedListQueryHandler(IRepoService<Delivery> service,
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

        public async Task<DeliveryRelatedListVm> Handle(GetDeliveryRelatedListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var deliveries = await _service.GetRelatedDataAsync();

            if (deliveries == null)
                throw new NotFoundException(nameof(Delivery), request);

            var deliveriesQuery = deliveries.Select(_mapper.Map<DeliveryRelatedLookupDto>).ToList();

            return new DeliveryRelatedListVm { Deliveries = deliveriesQuery };
        }
    }
}
