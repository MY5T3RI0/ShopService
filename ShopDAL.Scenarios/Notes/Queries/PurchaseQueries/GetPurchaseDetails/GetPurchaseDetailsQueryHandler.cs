using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails
{
    public class GetPurchaseDetailsQueryHandler : IRequestHandler<GetPurchaseDetailsQuery, PurchaseDetailsVm>
    {
        private readonly IRepoService<Purchase> _service;
        private readonly IMapper _mapper;

        public GetPurchaseDetailsQueryHandler(IRepoService<Purchase> service, IMapper mapper)
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

        public async Task<PurchaseDetailsVm> Handle(GetPurchaseDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Purchase), request.Id);

            return _mapper.Map<PurchaseDetailsVm>(entity);
        }
    }
}
