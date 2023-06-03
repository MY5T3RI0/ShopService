using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;
using ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreDetails;

namespace ShopDAL.Scenarios.Notes.Queries.StoreQueries.GetStoreRelatedList
{
    public class StoreRelatedLookupDto : IMapWith<Store>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PurchaseDto> Purchases { get; set; }
        public List<DeliveryDto> Deliveries { get; set; }
        public List<ProductsInStoreDto> ProductsInStore { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Store, StoreRelatedLookupDto>()
                .ForMember(storeVm => storeVm.Name,
                opt => opt.MapFrom(store => store.Name))
                .ForMember(storeVm => storeVm.Id,
                opt => opt.MapFrom(store => store.Id));
        }
    }
}
