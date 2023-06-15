using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(productVm => productVm.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.CategoryId,
                opt => opt.MapFrom(product => product.CategoryId))
                .ForMember(productVm => productVm.ManufacturerId,
                opt => opt.MapFrom(product => product.ManufacturerId))
                .ForMember(productVm => productVm.Name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.ImageName,
                opt => opt.MapFrom(product => product.ImageName))
                .ForMember(productVm => productVm.Id,
                opt => opt.MapFrom(product => product.Id));
        }
    }
}
