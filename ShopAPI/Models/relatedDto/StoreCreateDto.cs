using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto
{
    public class StoreCreateDto : IMapWith<Delivery>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Store, StoreCreateDto>()
                .ForMember(deliveryInfoVm => deliveryInfoVm.Name,
                opt => opt.MapFrom(deliveryInfo => deliveryInfo.Name));
        }
    }
}
