using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;
using ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseRelated;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails
{
    public class GetPurchaseRelatedDetailsQueryHandler : IRequestHandler<GetPurchaseRelatedDetailsQuery, PurchaseRelatedDetailsVm>
    {
        private readonly IRepoService<Purchase> _service;
        private readonly IMapper _mapper;

        public GetPurchaseRelatedDetailsQueryHandler(IRepoService<Purchase> service, IMapper mapper)
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

        public async Task<PurchaseRelatedDetailsVm> Handle(GetPurchaseRelatedDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetRelatedDataAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Purchase), request.Id);

            return _mapper.Map<PurchaseRelatedDetailsVm>(entity);
        }
    }
}
