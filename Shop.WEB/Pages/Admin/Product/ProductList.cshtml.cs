using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Product
{
    public class ProductListModel : PageModel
    {
        private readonly ILogger<ProductListModel> _logger;
        private readonly Client client;
        public ICollection<ProductLookupDto> Products { get; private set; }

        public ProductListModel(ILogger<ProductListModel> logger, Client client)
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
