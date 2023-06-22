using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Product;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Category
{
    public class CategoryListModel : PageModel
    {
        private readonly ILogger<CategoryListModel> _logger;
        private readonly Client client;
        private readonly string _version;

        public ICollection<CategoryLookupDto> Categories { get; private set; }
        public List<string> ValidationErrors { get; set; }

        public CategoryListModel(ILogger<CategoryListModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Categories = new List<CategoryLookupDto>();
            _version = "1.0";
        }

        public async Task OnGet()
        {
            var Category = await client.GetAllCategoryAsync(_version);
            Categories = Category.Categories;
        }
        public async Task OnPost(int id, string name)
        {
            if (!ModelState.IsValid)
            {
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var _Category = new UpdateCategoryDto
                {
                    Id = id,
                    Name = name
                };
                await client.UpdateCategoryAsync(_version, _Category);
            }

            await OnGet();
        }
    }
}
