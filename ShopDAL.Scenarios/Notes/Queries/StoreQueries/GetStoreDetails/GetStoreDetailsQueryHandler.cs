using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails
{
    public class GetStoreDetailsQueryHandler : IRequestHandler<GetStoreDetailsQuery, StoreDetailsVm>
    {
        private readonly IRepoService<Store> _service;
        private readonly IMapper _mapper;

        public GetStoreDetailsQueryHandler(IRepoService<Store> service, IMapper mapper)
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

        public async Task<StoreDetailsVm> Handle(GetStoreDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _service.GetOneAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Store), request.Id);

            return _mapper.Map<StoreDetailsVm>(entity);
        }
    }
}
