using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Delivery;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Product
{
    public class ProductDeleteModel : PageModel
    {
        private readonly ILogger<ProductDeleteModel> _logger;
        private readonly Client client;
        private readonly string _version;
        public ProductRelatedDetailsVm Product { get; set; }

        public ProductDeleteModel(ILogger<ProductDeleteModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Product = await client.GetRelatedProductAsync(id, _version);
        }

        public async Task<IActionResult> OnPost(ProductRelatedDetailsVm Product)
        {
            await client.DeleteProductAsync(Product.Id, _version);

            return RedirectToPage("/Admin/Product/ProductList");
        }
    }
}


