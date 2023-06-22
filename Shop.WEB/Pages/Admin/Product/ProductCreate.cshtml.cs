using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Product
{
    public class ProductCreateModel : PageModel
    {
        private readonly ILogger<ProductCreateModel> _logger;
        private readonly Client client;

        [BindProperty]
        public CreateProductDto Product { get; private set; }

        public List<string> ValidationErrors { get; set; }

        [BindProperty]
        public CategoryListVm Categories { get; set; }

        [BindProperty]
        public ManufacturerListVm Manufacturers { get; set; }

        [ValidateNever]
        public IFormFile Photo { get; set; }

        private readonly IWebHostEnvironment _env;

        private readonly string _version;

        public ProductCreateModel(ILogger<ProductCreateModel> logger, Client client, IWebHostEnvironment env)
        {
            _logger = logger;
            this.client = client;
            _env = env;
            _version = "1.0";
            Product = new CreateProductDto();
            Manufacturers = new ManufacturerListVm();
            Categories = new CategoryListVm();
            ValidationErrors = new List<string>();
        }

        public async Task<IActionResult> OnGet()
        {
            Categories = await client.GetAllCategoryAsync(_version);
            Manufacturers = await client.GetAllManufacturerAsync(_version);

            return Page();
        }

        public async Task<IActionResult> OnPost(CreateProductDto product)
        {
            Categories = await client.GetAllCategoryAsync(_version);
            Manufacturers = await client.GetAllManufacturerAsync(_version);

            Product = product;

            if (Photo != null)
                Product.ImageName = Photo.FileName;
            else
                Product.ImageName = "no-image.png";

            try
            {
                var result = await client.CreateProductAsync(_version, Product);
                UploadImage(Product, result);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                Product.ImageName="no-image.png";
            }

            if (!ModelState.IsValid)
            {
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Page();
            }

            return RedirectToPage("/Admin/Product/ProductList");
        }

        private void UploadImage(CreateProductDto product, int id)
        {
            string path1 = Path.Combine(_env.WebRootPath, "Content/Images");
            string path2 = Path.Combine(path1, "Uploads");
            string path3 = Path.Combine(path2, "Products");
            string path4 = Path.Combine(path3, $"{id}");
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
