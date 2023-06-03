using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseList
{
    public class GetPurchaseListQueryHandler : IRequestHandler<GetPurchaseListQuery, PurchaseListVm>
    {
        private readonly IRepoService<Purchase> _service;
        private readonly IMapper _mapper;

        public GetPurchaseListQueryHandler(IRepoService<Purchase> service,
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

        public async Task<PurchaseListVm> Handle(GetPurchaseListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entities = await _service.GetAllAsync();

            if (entities == null)
                throw new NotFoundException(nameof(Purchase), request);

            var entitiesQuery = entities.Select(_mapper.Map<PurchaseLookupDto>).ToList();

            return new PurchaseListVm { Purchases = entitiesQuery };
        }
    }
}
