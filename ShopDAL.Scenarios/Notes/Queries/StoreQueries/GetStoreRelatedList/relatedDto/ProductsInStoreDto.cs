using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto
{
    public class ProductsInStoreDto : IMapWith<ProductsInStore>
    {
        public int ProductId { get; set; }
        public int Count { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<ProductsInStore, ProductsInStoreDto>()
                .ForMember(productVm => productVm.ProductId,
                opt => opt.MapFrom(product => product.ProductId))
                .ForMember(productVm => productVm.Count,
                opt => opt.MapFrom(product => product.Count));
        }
    }
}
