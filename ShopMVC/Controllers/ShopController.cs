using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopDAL.Models;
using ShopMVC.Models;
using System.Diagnostics;

namespace ShopMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly string _baseUrl;
        public ProductController(IConfiguration configuration)
        {
            _baseUrl = configuration.GetSection("ServiceAddress").Value;
        }

        [HttpGet]
        private async Task<Product> GetProduct(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id} ");
            if (response.IsSuccessStatusCode)
            {
                var product = JsonConvert.DeserializeObject<Product>(
                await response.Content.ReadAsStringAsync());
                return product;
            }
            return null;
        }

        public async Task<IActionResult> GetProductList()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var items = JsonConvert.DeserializeObject<List<Product>>(
                await response.Content.ReadAsStringAsync());
                return View(items);
            }
            return NotFound();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var inventory = await GetProduct(id.Value);
            return inventory != null ? (IActionResult)View(inventory) : NotFound();
        }
    }
}