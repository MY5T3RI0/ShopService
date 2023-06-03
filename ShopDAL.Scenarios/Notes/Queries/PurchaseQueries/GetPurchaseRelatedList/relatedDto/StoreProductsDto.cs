using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto
{
    public class StoreProductsDto : IMapWith<StoreProducts>
    {
        public int StoreId { get; set; }
        public List<PurchaseDetailsDto> PurchaseDetails { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<StoreProducts, StoreProductsDto>()
                .ForMember(productVm => productVm.StoreId,
                opt => opt.MapFrom(product => product.StoreId));
        }
    }
}
