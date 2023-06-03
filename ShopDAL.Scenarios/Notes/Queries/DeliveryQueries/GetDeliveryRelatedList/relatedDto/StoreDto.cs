using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL.Scenarios.Notes.Queries.DeliveryQueries.GetDeliveryRelatedList.relatedDto
{
    public class StoreDto : IMapWith<Delivery>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Store, StoreDto>()
                .ForMember(deliveryInfoVm => deliveryInfoVm.Id,
                opt => opt.MapFrom(deliveryInfo => deliveryInfo.Id))
                .ForMember(deliveryInfoVm => deliveryInfoVm.Name,
                opt => opt.MapFrom(deliveryInfo => deliveryInfo.Name));
        }
    }
}
