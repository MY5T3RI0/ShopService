using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class DeliveryDetailsVm : IMapWith<Delivery>
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

            profile.CreateMap<Delivery, DeliveryDetailsVm>()
                .ForMember(deliveryVm => deliveryVm.Id,
                opt => opt.MapFrom(delievery => delievery.Id))
                .ForMember(deliveryVm => deliveryVm.Date,
                opt => opt.MapFrom(delievery => delievery.Date))
                .ForMember(deliveryVm => deliveryVm.StoreId,
                opt => opt.MapFrom(delievery => delievery.StoreId));
        }
    }
}
