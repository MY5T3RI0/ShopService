using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreLike
{
    public class GetStoreLikeQueryHandler : IRequestHandler<GetStoreLikeQuery, StoreLikeVm>
    {
        public IRepoService<Store> _service;
        private readonly IMapper _mapper;

        public GetStoreLikeQueryHandler(IRepoService<Store> service, IMapper mapper)
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

        public async Task<StoreLikeVm> Handle(GetStoreLikeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entities = await _service.SearchAsync(nameof(Store.Name), request.SearchString);

            if (entities == null)
                throw new NotFoundException(nameof(Store), request.SearchString);

            var entitiesQuery = entities.Select(_mapper.Map<StoreLikeLookupDto>).ToList();

            return new StoreLikeVm { Stores = entitiesQuery };
        }
    }
}
