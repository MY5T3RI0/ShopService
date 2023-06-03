using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;

namespace ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto
{
    public class DeliveryInfoCreateDto : IMapWith<DeliveryInfo>
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<DeliveryInfoCreateDto, DeliveryInfo>()
                .ForMember(deliveryInfoVm => deliveryInfoVm.ProductId,
                opt => opt.MapFrom(deliveryInfo => deliveryInfo.ProductId))
                .ForMember(deliveryInfoVm => deliveryInfoVm.ProductCount,
                opt => opt.MapFrom(deliveryInfo => deliveryInfo.ProductCount));
        }
    }
}
