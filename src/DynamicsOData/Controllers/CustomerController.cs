using DynamicsOData.Models.CustomerViewModel;
using DynamicsOData.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DynamicsOData.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private IODataService odataService;

        public CustomerController(IODataService odataService)
        {
            this.odataService = odataService;
        }

        public async Task<IActionResult> Index(string customerGroupId, string customerAccount)
        {
            var model = new IndexCustomerViewModel
            {
                CustomerGroupId = customerGroupId,
                CustomerAccount = customerAccount
            };

            if (string.IsNullOrEmpty(customerGroupId))
            {
                model.Customers = await odataService.GetCustomers();
            }
            else
            {
                model.Customers = await odataService.GetCustomersByGroup(customerGroupId);
            }

            return View(model);
        }
    }
}