using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class ProductLikeLookupDto : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Product, ProductLikeLookupDto>()
                .ForMember(productVm => productVm.Name,
                opt => opt.MapFrom(product => product.Name))
                 .ForMember(productVm => productVm.Price,
                opt => opt.MapFrom(product => product.Price));
        }
    }
}
