using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeDetails
{
    public class GetPriceChangeDetailsQueryHandler : IRequestHandler<GetPriceChangeDetailsQuery, PriceChangeDetailsVm>
    {
        private readonly IRepoService<PriceChange> _service;
        private readonly IMapper _mapper;

        public GetPriceChangeDetailsQueryHandler(IRepoService<PriceChange> service, IMapper mapper)
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

        public async Task<PriceChangeDetailsVm> Handle(GetPriceChangeDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(PriceChange), request.Id);

            return _mapper.Map<PriceChangeDetailsVm>(entity);
        }
    }
}
