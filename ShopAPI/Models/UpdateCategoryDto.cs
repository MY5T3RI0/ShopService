﻿using AutoMapper;
using ShopDAL.Scenarios.Common.Mappings;
using ShopDAL.Scenarios.Notes.Commands.ProductCommands.UpdateProduct;

namespace ShopAPI.Models
{
    public class UpdateCategoryDto : IMapWith<UpdateCategoryCommand>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, UpdateCategoryCommand>()
                .ForMember(categoryCommand => categoryCommand.Name,
                opt => opt.MapFrom(categoryDto => categoryDto.Name))
                .ForMember(categoryCommand => categoryCommand.Id,
                opt => opt.MapFrom(categoryDto => categoryDto.Id));
        }
    }
}
