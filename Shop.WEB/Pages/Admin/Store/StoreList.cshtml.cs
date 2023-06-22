using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopApi.Client;
using ShopDAL.Models;
using System;

namespace Shop.WEB.Pages.Admin.Store
{
    public class StoreListModel : PageModel
    {
        private readonly ILogger<StoreListModel> _logger;
        private readonly Client client;
        public ICollection<UpdateStoreDto> Stores { get; private set; }
        public List<string> ValidationErrors { get; set; }

        private string _version { get; set; }

        public StoreListModel(ILogger<StoreListModel> logger, Client client)
        {
            _logger = logger;
            this.client = client;
            Stores = new List<UpdateStoreDto>();
            _version = "1.0";
            ValidationErrors = new List<string>();
        }

        public async Task OnGet()
        {
            var stores = await client.GetAllStoreAsync("1.0");
            Stores = stores.Stores.Select(x => new UpdateStoreDto { Id = x.Id, Name = x.Name}).ToList();
        }

        public async Task OnPost(int id, string name)
        {

            if (!ModelState.IsValid)
            {
                ValidationErrors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var _Store = new UpdateStoreDto
                {
                    Id = id,
                    Name = name
                };
                await client.UpdateStoreAsync(_version, _Store);
            }

            await OnGet();
        }
    }
}
