using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Product;
using ShopApi.Client;
using System.Windows.Input;
using System.Xml.Linq;

namespace Shop.WEB.Pages.Admin.Customer
{
    public class CustomerListModel : PageModel
    {
        private readonly ILogger<CustomerListModel> _logger;
        private readonly Client client;
        private readonly string _version;

        public ICollection<CustomerLookupDto> Customers { get; private set; }
        public List<string> ValidationErrors { get; set; }

        public CustomerListModel(ILogger<CustomerListModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Customers = new List<CustomerLookupDto>();
            _version = "1.0";
        }

        public async Task OnGet()
        {
            var Customer = await client.GetAllCustomerAsync(_version);
            Customers = Customer.Customers;
        }
        public async Task OnPost(int id, string name)
        {
            if (!ModelState.IsValid)
            {
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var _Customer = new UpdateCustomerDto
                {
                    Id = id,
                    Name = name
                };
                await client.UpdateCustomerAsync(_version, _Customer);
            }

            await OnGet();
        }
    }
}
