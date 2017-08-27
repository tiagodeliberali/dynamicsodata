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

        public async Task<IActionResult> Index()
        {
            var groups = await odataService.GetCustomers();

            return View(groups);
        }
    }
}