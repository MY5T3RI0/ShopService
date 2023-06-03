using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeList
{
    public class GetPriceChangeListQueryHandler : IRequestHandler<GetPriceChangeListQuery, PriceChangeListVm>
    {
        private readonly IRepoService<PriceChange> _service;
        private readonly IMapper _mapper;

        public GetPriceChangeListQueryHandler(IRepoService<PriceChange> service,
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

        public async Task<PriceChangeListVm> Handle(GetPriceChangeListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var categories = await _service.GetAllAsync();

            if (categories == null)
                throw new NotFoundException(nameof(PriceChange), request);

            var categoriesQuery = categories.Select(_mapper.Map<PriceChangeLookupDto>).ToList();

            return new PriceChangeListVm { PriceChanges = categoriesQuery };
        }
    }
}
