using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;

namespace Shop.WEB.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly ILogger<CatalogModel> _logger;
        private readonly Client client;
        public ICollection<ProductLookupDto> Products { get; private set; }

        public CatalogModel(ILogger<CatalogModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Products = new List<ProductLookupDto>();
        }

        public async Task OnGet()
        {
            var products = await client.GetAllProductAsync("1.0");
            Products = products.Products;
        }
    }
}