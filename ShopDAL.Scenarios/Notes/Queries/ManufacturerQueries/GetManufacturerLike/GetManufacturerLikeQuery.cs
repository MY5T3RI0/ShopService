﻿using MediatR;
using ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductDetails;

namespace ShopDAL.Scenarios.Notes.Queries.ProductQueries.GetProductLike
{
    public class GetManufacturerLikeQuery : IRequest<ManufacturerLikeVm>
    {
        public string SearchString { get; set; }
    }
}
