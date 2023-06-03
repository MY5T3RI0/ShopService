using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class CategoryLookupDto : IMapWith<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Category, CategoryLookupDto>()
                .ForMember(deliveryVm => deliveryVm.Name,
                opt => opt.MapFrom(delivery => delivery.Name))
                .ForMember(deliveryVm => deliveryVm.Id,
                opt => opt.MapFrom(delivery => delivery.Id));
        }
    }
}
