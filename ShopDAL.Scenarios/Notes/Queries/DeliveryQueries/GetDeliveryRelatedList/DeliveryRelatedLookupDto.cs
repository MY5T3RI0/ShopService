using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList
{
    public class DeliveryRelatedLookupDto : IMapWith<Delivery>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public StoreDto Store { get; set; }
        public List<DeliveryInfoDto> DeliveryInfos { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Delivery, DeliveryRelatedLookupDto>()
                .ForMember(deliveryVm => deliveryVm.Id,
                opt => opt.MapFrom(delivery => delivery.Id))
                .ForMember(deliveryVm => deliveryVm.Date,
                opt => opt.MapFrom(delivery => delivery.Date));
        }
    }
}
