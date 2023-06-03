using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class DeliveryLookupDto : IMapWith<Delivery>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int StoreId { get; set; }
        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Delivery, DeliveryLookupDto>()
                .ForMember(deliveryVm => deliveryVm.Date,
                opt => opt.MapFrom(delivery => delivery.Date))
                .ForMember(deliveryVm => deliveryVm.StoreId,
                opt => opt.MapFrom(delivery => delivery.StoreId))
                .ForMember(deliveryVm => deliveryVm.Id,
                opt => opt.MapFrom(delivery => delivery.Id));
        }
    }
}
