using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetDeliveryLikeQueryHandler : IRequestHandler<GetDeliveryLikeQuery, DeliveryLikeVm>
    {
        public IRepoService<Delivery> _service;
        private readonly IMapper _mapper;

        public GetDeliveryLikeQueryHandler(IRepoService<Delivery> service, IMapper mapper)
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

        public async Task<DeliveryLikeVm> Handle(GetDeliveryLikeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var deliveries = await _service.SearchAsync(nameof(Delivery.Date), request.SearchString);

            if (deliveries == null)
                throw new NotFoundException(nameof(Delivery), request.SearchString);

            var deliveriesQuery = deliveries.Select(_mapper.Map<DeliveryLikeLookupDto>).ToList();

            return new DeliveryLikeVm { Deliveries = deliveriesQuery };
        }
    }
}
