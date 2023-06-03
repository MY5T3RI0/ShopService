using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelatedList
{
    public class GetPriceChangeRelatedListQueryHandler : IRequestHandler<GetPriceChangeRelatedListQuery, PriceChangeRelatedListVm>
    {
        private readonly IRepoService<PriceChange> _service;
        private readonly IMapper _mapper;

        public GetPriceChangeRelatedListQueryHandler(IRepoService<PriceChange> service,
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

        public async Task<PriceChangeRelatedListVm> Handle(GetPriceChangeRelatedListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var priceChanges = await _service.GetRelatedDataAsync();

            if (priceChanges == null)
                throw new NotFoundException(nameof(PriceChange), request);

            var priceChangesQuery = priceChanges.Select(_mapper.Map<PriceChangeRelatedLookupDto>).ToList();

            return new PriceChangeRelatedListVm { PriceChanges = priceChangesQuery };
        }
    }
}
