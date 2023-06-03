using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, CategoryListVm>
    {
        private readonly IRepoService<Category> _service;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IRepoService<Category> service,
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

        public async Task<CategoryListVm> Handle(GetCategoryListQuery request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var categories = await _service.GetAllAsync();

            if (categories == null)
                throw new NotFoundException(nameof(Category), request);

            var categoriesQuery = categories.Select(_mapper.Map<CategoryLookupDto>).ToList();

            return new CategoryListVm { Categories = categoriesQuery };
        }
    }
}
