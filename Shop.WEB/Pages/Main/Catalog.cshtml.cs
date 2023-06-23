using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;

namespace Shop.WEB.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly ILogger<CatalogModel> _logger;
        private readonly Client client;
        public ICollection<ProductLookupDto> Products { get; private set; }

        private readonly string _version;

        public CatalogModel(ILogger<CatalogModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Products = new List<ProductLookupDto>();
            _version = "1.0";
        }

        public async Task OnGet(string namePart = "")
        {
            var products = await client.GetAllProductAsync("1.0");
            Products = products.Products;
        }

        public async Task OnGetLike(string namePart)
        {
            var products = await client.GetProductLikeAsync(namePart, _version);
            Products = products.Products.Select(x => new ProductLookupDto { Name = x.Name, Price = x.Price, ImageName = x.ImageName, Id = x.Id}).ToList();
        }

    }
}