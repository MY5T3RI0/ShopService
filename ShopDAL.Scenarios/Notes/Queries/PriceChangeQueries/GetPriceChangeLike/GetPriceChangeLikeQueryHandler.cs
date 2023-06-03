using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.PriceChangeQueries.GetPriceChangeLike
{
    public class GetPriceChangeLikeQueryHandler : IRequestHandler<GetPriceChangeLikeQuery, PriceChangeLikeVm>
    {
        public IRepoService<PriceChange> _service;
        private readonly IMapper _mapper;

        public GetPriceChangeLikeQueryHandler(IRepoService<PriceChange> service, IMapper mapper)
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

        public async Task<PriceChangeLikeVm> Handle(GetPriceChangeLikeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var categories = await _service.SearchAsync(nameof(PriceChange.DateOfChange), request.SearchString);

            if (categories == null)
                throw new NotFoundException(nameof(PriceChange), request.SearchString);

            var categoriesQuery = categories.Select(_mapper.Map<PriceChangeLikeLookupDto>).ToList();

            return new PriceChangeLikeVm { PriceChanges = categoriesQuery };
        }
    }
}
