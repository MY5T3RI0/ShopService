using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class GetDeliveryRelatedDetailsQueryHandler : IRequestHandler<GetDeliveryRelatedDetailsQuery, DeliveryRelatedDetailsVm>
    {
        private readonly IRepoService<Delivery> _service;
        private readonly IMapper _mapper;

        public GetDeliveryRelatedDetailsQueryHandler(IRepoService<Delivery> service, IMapper mapper)
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

        public async Task<DeliveryRelatedDetailsVm> Handle(GetDeliveryRelatedDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetRelatedDataAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Delivery), request.Id);

            return _mapper.Map<DeliveryRelatedDetailsVm>(entity);
        }
    }
}
