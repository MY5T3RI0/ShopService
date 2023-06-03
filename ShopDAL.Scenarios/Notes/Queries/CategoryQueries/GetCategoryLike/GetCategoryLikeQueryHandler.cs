using AutoMapper;
using MediatR;
using ShopAPI.Services;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Exceptions;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetCategoryLikeQueryHandler : IRequestHandler<GetCategoryLikeQuery, CategoryLikeVm>
    {
        public IRepoService<Category> _service;
        private readonly IMapper _mapper;

        public GetCategoryLikeQueryHandler(IRepoService<Category> service, IMapper mapper)
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

        public async Task<CategoryLikeVm> Handle(GetCategoryLikeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var categories = await _service.SearchAsync(nameof(Category.Name), request.SearchString);

            if (categories == null)
                throw new NotFoundException(nameof(Category), request.SearchString);

            var categoriesQuery = categories.Select(_mapper.Map<CategoryLikeLookupDto>).ToList();

            return new CategoryLikeVm { Categories = categoriesQuery };
        }
    }
}
