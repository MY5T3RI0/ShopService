using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseRelatedList
{
    public class GetPurchaseRelatedListQueryHandler : IRequestHandler<GetPurchaseRelatedListQuery, PurchaseRelatedListVm>
    {
        private readonly IRepoService<Purchase> _service;
        private readonly IMapper _mapper;

        public GetPurchaseRelatedListQueryHandler(IRepoService<Purchase> service,
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

        public async Task<PurchaseRelatedListVm> Handle(GetPurchaseRelatedListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var purchases = await _service.GetRelatedDataAsync();

            if (purchases == null)
                throw new NotFoundException(nameof(Purchase), request);

            var purchasesQuery = purchases.Select(_mapper.Map<PurchaseRelatedLookupDto>).ToList();

            return new PurchaseRelatedListVm { Purchases = purchasesQuery };
        }
    }
}
