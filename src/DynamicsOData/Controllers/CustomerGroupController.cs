using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DynamicsOData.Services;

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

        public async Task<IActionResult> Index()
        {
            var groups = await odataService.GetCustomerGroups();

            return View(groups);
        }
    }
}