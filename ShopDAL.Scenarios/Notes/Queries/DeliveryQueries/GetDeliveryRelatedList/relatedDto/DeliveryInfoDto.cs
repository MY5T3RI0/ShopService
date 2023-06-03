using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList;

namespace ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto
{
    public class DeliveryInfoDto : IMapWith<DeliveryInfo>
    {
        public int ProductId { get; set; }
        public int DeliveryId { get; set; }
        public int ProductCount { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<DeliveryInfo, DeliveryInfoDto>()
                .ForMember(deliveryInfoVm => deliveryInfoVm.ProductId,
                opt => opt.MapFrom(deliveryInfo => deliveryInfo.ProductId))
                .ForMember(deliveryInfoVm => deliveryInfoVm.ProductCount,
                opt => opt.MapFrom(deliveryInfo => deliveryInfo.ProductCount))
                .ForMember(deliveryInfoVm => deliveryInfoVm.DeliveryId,
                opt => opt.MapFrom(deliveryInfo => deliveryInfo.DeliveryId));
        }
    }
}
