using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WEB.Pages.Admin.Delivery;
using ShopApi.Client;

namespace Shop.WEB.Pages.Admin.Customer
{
    public class CustomerDeleteModel : PageModel
    {
        private readonly ILogger<CustomerDeleteModel> _logger;
        private readonly Client client;
        private readonly string _version;
        public CustomerDetailsVm Customer { get; set; }

        public CustomerDeleteModel(ILogger<CustomerDeleteModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            _version = "1.0";
        }

        public async Task OnGet(int id)
        {
            Customer = await client.GetCustomerAsync(id, _version);
        }

        public async Task<IActionResult> OnPost(CustomerDetailsVm customer)
        {
            await client.DeleteCustomerAsync(customer.Id, _version);

            return RedirectToPage("/Admin/Customer/CustomerList");
        }
    }
}


