using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreRelatedList
{
    public class GetStoreRelatedListQueryHandler : IRequestHandler<GetStoreRelatedListQuery, StoreRelatedListVm>
    {
        private readonly IRepoService<Store> _service;
        private readonly IMapper _mapper;

        public GetStoreRelatedListQueryHandler(IRepoService<Store> service,
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

        public async Task<StoreRelatedListVm> Handle(GetStoreRelatedListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var stores = await _service.GetRelatedDataAsync();

            if (stores == null)
                throw new NotFoundException(nameof(Store), request);

            var storesQuery = stores.Select(_mapper.Map<StoreRelatedLookupDto>).ToList();

            return new StoreRelatedListVm { Stores = storesQuery };
        }
    }
}
