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

namespace Shop.WEB.Pages.Admin.Product
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ILogger<ProductDetailsModel> _logger;
        private readonly Client client;

        [BindProperty]
        public UpdateProductDto Product { get; private set; }
        public List<string> ValidationErrors { get; set; }

        [BindProperty]
        public CategoryListVm Categories { get; set; }

        [BindProperty]
        public ManufacturerListVm Manufacturers { get; set; }

        public IEnumerable<string> GalleryImages { get; private set; }

        public ICollection<PriceChangesDto> PriceChanges { get; set; }

        [ValidateNever]
        public IFormFile Photo { get; set; }

        private readonly IWebHostEnvironment _env;

        private readonly string _version;

        public ProductDetailsModel(ILogger<ProductDetailsModel> logger, Client client, IWebHostEnvironment env)
        {
            _logger = logger;
            this.client = client;
            _env = env;
            Product = new UpdateProductDto();
            GalleryImages = new List<string>();
            Categories = new CategoryListVm();
            Manufacturers = new ManufacturerListVm();
            _version = "1.0";
            ValidationErrors = new List<string>();
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var tempProd = await client.GetRelatedProductAsync(id, _version);
            Product.CategoryId = tempProd.Category.Id;
            Product.ManufacturerId = tempProd.Manufacturer.Id;
            Product.ImageName = tempProd.ImageName;
            Product.Name = tempProd.Name;
            Product.Price = tempProd.Price;
            Product.Id = tempProd.Id;
            PriceChanges = tempProd.PriceChanges;

            Categories = await client.GetAllCategoryAsync(_version);
            Manufacturers = await client.GetAllManufacturerAsync(_version);

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

        public async Task<IActionResult> OnPost(UpdateProductDto product)
        {
            await OnGet(product.Id);

            ModelState.Remove("Photo");

            if (!ModelState.IsValid)
            {
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Page();
            }

            if (Photo != null)
                product.ImageName = Photo.FileName;
            else
                product.ImageName = Product.ImageName;

            try
            {

                if(Product.Price != product.Price)
                {
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
                }

                await client.UpdateProductAsync(_version, product);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            if (!ModelState.IsValid)
            {
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Page();
            }

            if (Photo != null)
                UploadImage(product);

            //to reload page without js
            return await OnGet(product.Id);
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
