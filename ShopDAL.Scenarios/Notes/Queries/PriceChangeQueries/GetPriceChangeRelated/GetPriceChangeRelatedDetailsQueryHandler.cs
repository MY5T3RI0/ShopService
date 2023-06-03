using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;
using ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeRelated;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails
{
    public class GetPriceChangeRelatedDetailsQueryHandler : IRequestHandler<GetPriceChangeRelatedDetailsQuery, PriceChangeRelatedDetailsVm>
    {
        private readonly IRepoService<PriceChange> _service;
        private readonly IMapper _mapper;

        public GetPriceChangeRelatedDetailsQueryHandler(IRepoService<PriceChange> service, IMapper mapper)
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

        public async Task<PriceChangeRelatedDetailsVm> Handle(GetPriceChangeRelatedDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetRelatedDataAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(PriceChange), request.Id);

            return _mapper.Map<PriceChangeRelatedDetailsVm>(entity);
        }
    }
}
