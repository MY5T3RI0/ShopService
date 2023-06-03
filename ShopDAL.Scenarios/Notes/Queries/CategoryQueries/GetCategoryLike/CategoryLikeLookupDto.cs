using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class CategoryLikeLookupDto : IMapWith<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Category, CategoryLikeLookupDto>()
                .ForMember(categoryVm => categoryVm.Id,
                opt => opt.MapFrom(category => category.Id))
                .ForMember(categoryVm => categoryVm.Name,
                opt => opt.MapFrom(category => category.Name));
        }
    }
}
