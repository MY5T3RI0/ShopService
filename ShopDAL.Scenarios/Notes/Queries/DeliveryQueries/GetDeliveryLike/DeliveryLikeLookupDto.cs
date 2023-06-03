using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class DeliveryLikeLookupDto : IMapWith<Delivery>
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

            profile.CreateMap<Delivery, DeliveryLikeLookupDto>()
                .ForMember(deliveryVm => deliveryVm.Id,
                opt => opt.MapFrom(delivery => delivery.Id))
                .ForMember(deliveryVm => deliveryVm.Date,
                opt => opt.MapFrom(delivery => delivery.Date))
                 .ForMember(deliveryVm => deliveryVm.StoreId,
                opt => opt.MapFrom(delivery => delivery.StoreId));
        }
    }
}
