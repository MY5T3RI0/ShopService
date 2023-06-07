using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;
using ShopDAL.Models;

namespace Shop.WEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Client client;

        public IndexModel(ILogger<IndexModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;   
        }

        public ICollection<ProductLookupDto> Products { get; private set; }

        public async Task OnGet()
        {
            var products = await client.GetAllProductAsync("1.0");
            Products = products.Products;
        }
    }
}