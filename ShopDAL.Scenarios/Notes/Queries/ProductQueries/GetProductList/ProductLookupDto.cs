using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(productVm => productVm.Name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Id,
                opt => opt.MapFrom(product => product.Id));
        }
    }
}
