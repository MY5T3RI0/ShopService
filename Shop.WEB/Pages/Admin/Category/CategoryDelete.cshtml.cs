using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Delivery;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Category
{
    public class CategoryDeleteModel : PageModel
    {
        private readonly ILogger<CategoryDeleteModel> _logger;
        private readonly Client client;
        private readonly string _version;
        public CategoryDetailsVm Category { get; set; }

        public CategoryDeleteModel(ILogger<CategoryDeleteModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Category = await client.GetCategoryAsync(id, _version);
        }

        public async Task<IActionResult> OnPost(CategoryDetailsVm Category)
        {
            await client.DeleteCategoryAsync(Category.Id, _version);

            return RedirectToPage("/Admin/Category/CategoryList");
        }
    }
}


