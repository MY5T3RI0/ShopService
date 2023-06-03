using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails
{
    public class ProductRelatedDetailsVm : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Category Category { get; set; }
        public List<PriceChangesDto> PriceChanges { get; set; }

        public void Mapping(Profile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            profile.CreateMap<Product, ProductRelatedDetailsVm>()
                .ForMember(productVm => productVm.Name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Manufacturer,
                opt => opt.MapFrom(product => product.Manufacturer))
                .ForMember(productVm => productVm.Category,
                opt => opt.MapFrom(product => product.Category))
                .ForMember(productVm => productVm.Id,
                opt => opt.MapFrom(product => product.Id));
        }
    }
}
