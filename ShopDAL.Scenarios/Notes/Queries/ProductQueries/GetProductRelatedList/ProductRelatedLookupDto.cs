﻿using AutoMapper;
using ShopDAL.Models;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList.relatedDto;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductRelatedList
{
    public class ProductRelatedLookupDto : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
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

            profile.CreateMap<Product, ProductRelatedLookupDto>()
                .ForMember(productVm => productVm.Name,
                opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Price,
                opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Manufacturer,
                opt => opt.MapFrom(product => product.Manufacturer))
                .ForMember(productVm => productVm.Category,
                opt => opt.MapFrom(product => product.Category))
                .ForMember(productVm => productVm.ImageName,
                opt => opt.MapFrom(product => product.ImageName))
                .ForMember(productVm => productVm.Id,
                opt => opt.MapFrom(product => product.Id));
        }
    }
}
