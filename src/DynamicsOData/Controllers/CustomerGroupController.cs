using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DynamicsOData.Services;
using DynamicsOData.Models.CustomerGroupViewModel;

namespace DynamicsOData.Controllers
{
    [Authorize]
    public class CustomerGroupController : Controller
    {
        private IODataService odataService;

        public CustomerGroupController(IODataService odataService)
        {
            this.odataService = odataService;
        }

        public async Task<IActionResult> Index(string customerGroupId)
        {
            var model = new IndexCustomerGroupViewModel
            {
                Groups = await odataService.GetCustomerGroups(),
                CustomerGroupId = customerGroupId
            };

            return View(model);
        }
    }
}