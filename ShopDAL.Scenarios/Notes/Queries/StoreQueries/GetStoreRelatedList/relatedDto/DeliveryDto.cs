using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto
{
    public class DeliveryDto : IMapWith<Delivery>
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Delivery, DeliveryDto>()
                .ForMember(productVm => productVm.Id,
                opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.Date,
                opt => opt.MapFrom(product => product.Date));
        }
    }
}
