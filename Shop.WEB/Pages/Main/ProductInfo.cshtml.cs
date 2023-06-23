using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApi.Client;
using ShopDAL.Models;
using System.ComponentModel;
using System.IO;

namespace Shop.WEB.Pages
{
    public class ProductInfoModel : PageModel
    {
        private readonly ILogger<ProductInfoModel> _logger;
        private readonly Client client;

        [BindProperty]
        public ProductRelatedDetailsVm Product { get; private set; }

        public IEnumerable<string> GalleryImages { get; private set; }

        private readonly IWebHostEnvironment _env;

        private readonly string _version;

        public ProductInfoModel(ILogger<ProductInfoModel> logger, Client client, IWebHostEnvironment env)
        {
            _logger = logger;
            this.client = client;
            _env = env;
            Product = new ProductRelatedDetailsVm();
            GalleryImages = new List<string>();
            _version = "1.0";
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Product = await client.GetRelatedProductAsync(id, _version);

            var path = Path.Combine(_env.WebRootPath, "Content", "Images", "Uploads", "Products", id.ToString(), "Thumbs");
            try
            {
                GalleryImages = Directory.EnumerateFiles(path).Select(f => Path.GetFileName(f));
            }
            catch
            {
                for (int i = 0; i < 3; i++)
                {
                    GalleryImages = new List<string> { "~/Content/img/no-image.png", "~/Content/img/no-image.png", "~/Content/img/no-image.png" };
                }
            }

            return Page();
        }

    }
}
