using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseLike
{
    public class GetPurchaseLikeQueryHandler : IRequestHandler<GetPurchaseLikeQuery, PurchaseLikeVm>
    {
        public IRepoService<Purchase> _service;
        private readonly IMapper _mapper;

        public GetPurchaseLikeQueryHandler(IRepoService<Purchase> service, IMapper mapper)
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

        public async Task<PurchaseLikeVm> Handle(GetPurchaseLikeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entities = await _service.SearchAsync(nameof(Purchase.Date), request.SearchString);

            if (entities == null)
                throw new NotFoundException(nameof(Purchase), request.SearchString);

            var entitiesQuery = entities.Select(_mapper.Map<PurchaseLikeLookupDto>).ToList();

            return new PurchaseLikeVm { Purchases = entitiesQuery };
        }
    }
}
