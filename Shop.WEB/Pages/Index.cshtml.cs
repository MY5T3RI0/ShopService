using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;
using System;
using System.Collections.Generic;

namespace Shop.WEB.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;
        private readonly Client client;
        public ICollection<ProductLookupDto> Products { get; private set; }

        public HomeModel(ILogger<HomeModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Products = new List<ProductLookupDto>();
        }

        public async Task OnGet()
        {
            var products = await client.GetAllProductAsync("1.0");
            for (int i = 0; i < 3; i++)
            {
                Products = products.Products.OrderBy(x => new Random().Next()).Take(3).ToList();
            }
        }

        public void OnPostAdminArea()
        {
            TempData["Layout"] = "~/Views/Shared/_LayoutAdmin.cshtml";
        }
    }
}
