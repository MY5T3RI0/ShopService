using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.PurchaseQueries.GetPurchaseDetails
{
    public class PurchaseDetailsVm : IMapWith<Purchase>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int CustomerId { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Purchase, PurchaseDetailsVm>()
                .ForMember(purchaseVm => purchaseVm.Id,
                opt => opt.MapFrom(purchase => purchase.Id))
                .ForMember(purchaseVm => purchaseVm.CustomerId,
                opt => opt.MapFrom(purchase => purchase.CustomerId))
                .ForMember(purchaseVm => purchaseVm.Date,
                opt => opt.MapFrom(purchase => purchase.Date));
        }
    }
}
