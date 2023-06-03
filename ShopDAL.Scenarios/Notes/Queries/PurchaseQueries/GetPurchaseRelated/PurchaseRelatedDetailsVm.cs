using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails
{
    public class PurchaseRelatedDetailsVm : IMapWith<Purchase>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public Customer Customer { get; set; }
        public List<StoreProductsDto> StoreProducts { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Purchase, PurchaseRelatedDetailsVm>()
                .ForMember(purchaseVm => purchaseVm.Date,
                opt => opt.MapFrom(purchase => purchase.Date))
                .ForMember(purchaseVm => purchaseVm.Customer,
                opt => opt.MapFrom(purchase => purchase.Customer))
                .ForMember(purchaseVm => purchaseVm.Id,
                opt => opt.MapFrom(purchase => purchase.Id));
        }
    }
}
