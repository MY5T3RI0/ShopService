using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class ProductDetailsVm : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Product, ProductDetailsVm>()
                .ForMember(productVm => productVm.Name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Id,
                opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.CategoryId,
                opt => opt.MapFrom(product => product.CategoryId))
                .ForMember(productVm => productVm.ManufacturerId,
                opt => opt.MapFrom(product => product.ManufacturerId));
        }
    }
}
