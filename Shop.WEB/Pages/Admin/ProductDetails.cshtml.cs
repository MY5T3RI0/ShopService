using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApi.Client;
using System.ComponentModel;

namespace Shop.WEB.Pages.Admin
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ILogger<ProductDetailsModel> _logger;
        private readonly Client client;
        public ProductDetailsVm Product { get; private set; }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Manufacturers { get; set; }
        public IEnumerable<string> GalleryImages { get; private set; }
        
        [BindProperty]
        public IFormFile Photo { get; set; }

        private readonly IWebHostEnvironment _env;

        private readonly string _version;

        public ProductDetailsModel(ILogger<ProductDetailsModel> logger, Client client, IWebHostEnvironment env)
        {
            _logger = logger;
            this.client = client;
            _env = env;
            Product = new ProductDetailsVm();
            GalleryImages = new List<string>();
            Categories = new List<SelectListItem>();
            Manufacturers = new List<SelectListItem>();
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Product = await client.GetProductAsync(id, _version);

            var categories = await client.GetAllCategoryAsync(_version);
            var manufacturers = await client.GetAllManufacturerAsync(_version);

            Categories = categories.Categories
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name
                })
                .ToList();

            Manufacturers = manufacturers.Manufacturers
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name
                })
                .ToList();

            var path = Path.Combine(_env.WebRootPath, "Content", "Images", "Uploads", "Products", id.ToString(), "Thumbs");
            try
            {
                GalleryImages = Directory.EnumerateFiles(path).Select(f => Path.GetFileName(f));
;            }
            catch
            {
                for (int i = 0; i < 3; i++)
                {
                    GalleryImages = new List<string> { "~/Content/img/no-image.png", "~/Content/img/no-image.png", "~/Content/img/no-image.png" };
                }
            }

        }

        public async Task OnPost(ProductDetailsVm product)
        {
            var Product = new UpdateProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ManufacturerId = product.ManufacturerId,
                CategoryId = product.CategoryId,
                ImageName = Photo.FileName
            };

            await client.UpdateProductAsync(_version, Product);

            var changesDetails = new ChangesDetailsCreateDto
            {
                ProductId = product.Id,
                NewPrice = product.Price
            };

            await client.CreatePriceChangeAsync(_version,
            new CreatePriceChangeDto
            {
                ChangeDetailsDto =
            new List<ChangesDetailsCreateDto> { changesDetails }
            });

            UploadImage(Product);

            await OnGet(product.Id);
        }

        private void UploadImage(UpdateProductDto product)
        {
            string path1 = Path.Combine(_env.WebRootPath, "Content/Images");
            string path2 = Path.Combine(path1, "Uploads");
            string path3 = Path.Combine(path2, "Products");
            string path4 = Path.Combine(path3, $"{product.Id}");
            string path5 = Path.Combine(path4, "Thumbs");
            string filePath = Path.Combine(path5, $"{product.ImageName}");

            Directory.CreateDirectory(path1);
            Directory.CreateDirectory(path2);
            Directory.CreateDirectory(path3);
            Directory.CreateDirectory(path4);
            Directory.CreateDirectory(path5);

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fs);
            }
        }

    }
}
