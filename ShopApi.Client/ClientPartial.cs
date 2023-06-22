using Microsoft.AspNetCore.Mvc;
using ShopApi.Client.Metadata.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopApi.Client
{
    [ModelMetadataType(typeof(ProductUpdateMetadata))]
    public partial class UpdateProductDto
    {

    }

}
