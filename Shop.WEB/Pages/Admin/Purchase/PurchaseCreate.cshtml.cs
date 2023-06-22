using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApi.Client;
using ShopDAL.Models;

namespace Shop.WEB.Pages.Admin.Purchase
{
    public class PurchaseCreateModel : PageModel
    {
        private readonly ILogger<PurchaseCreateModel> _logger;
        private readonly Client client;
        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public List<string> ValidationErrors { get; set; }

        private readonly IWebHostEnvironment _env;

        private readonly string _version;

        public PurchaseCreateModel(ILogger<PurchaseCreateModel> logger, Client client, IWebHostEnvironment env)
        {
            _logger = logger;
            this.client = client;
            _env = env;
            Products = new List<SelectListItem>();
            _version = "1.0";
        }

        public async Task OnGet()
        {
            var products = await client.GetAllProductAsync(_version);
            var customers = await client.GetAllCustomerAsync(_version);

            Products = products.Products
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name
                })
                .ToList();

            Customers = customers.Customers
                .Select(o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name
                })
                .ToList();
        }

        public async Task<IActionResult> OnPost(PurchaseDetailsCreateDto[] purchaseDetails, CustomerDetailsVm customer)
        {
            await OnGet();

            var stores = await client.GetAllRelatedStoreAsync(_version);

            var storeProducts = new List<StoreProductCreateDto>();

            var purchaseDetailses = purchaseDetails.Where(x => x.ProductCount > 0);

            if (!purchaseDetailses.Any())
            {
                ModelState.AddModelError("", "Incorrect product count");
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Page();
            }

            //go through all selected products
            foreach (var item in purchaseDetailses)
            {
                //check stores to have required product
                var actualStores = stores.Stores.Where(x => x.ProductsInStore.Any(x => x.ProductId == item.ProductId && x.Count > 0)).ToList();

                if (actualStores.Count == 0)
                {
                    ModelState.AddModelError("", "Not enought products");
                    ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Page();
                }

                var totalProductCount = 0;

                foreach (var store in actualStores)
                {
                    totalProductCount += store.ProductsInStore.Where(x => x.ProductId == item.ProductId).Sum(x => x.Count);
                }

                //check stores to could gave enougth product
                if (totalProductCount < item.ProductCount)
                {
                    ModelState.AddModelError("", "Not enought products");
                    ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return Page();
                }

                for (int i = 0; item.ProductCount > 0; i++)
                {
                    //check stores to have enougth product in one store
                    var idealStore = actualStores.FirstOrDefault(x => x.ProductsInStore.Any(x => x.ProductId == item.ProductId && x.Count >= item.ProductCount));

                    //if ideal store exists go to next product
                    if (idealStore != null)
                    {
                        storeProducts.Add(
                            new StoreProductCreateDto
                            {
                                StoreId = idealStore.Id,
                                PurchaseDetails = new List<PurchaseDetailsCreateDto>
                                {
                                    new PurchaseDetailsCreateDto
                                    {
                                        ProductId = item.ProductId,
                                        ProductCount = item.ProductCount,
                                    }
                                }
                            });

                        break;
                    }

                    //else give part of product from some store
                    storeProducts.Add(
                        new StoreProductCreateDto
                        {
                            StoreId = actualStores[i].Id,
                            PurchaseDetails = new List<PurchaseDetailsCreateDto>
                            {
                                new PurchaseDetailsCreateDto
                                {
                                    ProductId = item.ProductId,
                                    ProductCount = actualStores[i].ProductsInStore.FirstOrDefault(x => x.ProductId == item.ProductId).Count,
                                }

                            }
                        });

                    item.ProductCount -= actualStores[i].ProductsInStore.FirstOrDefault(x => x.ProductId == item.ProductId).Count;

                }
            }

            var Purchase = new CreatePurchaseDto
            {
                CustomerId = customer.Id,
                StoreProducts = storeProducts,
            };

            await client.CreatePurchaseAsync(_version, Purchase);

            return Page();
        }

    }
}
