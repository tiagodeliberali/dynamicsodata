using DynamicsOData.Models.CustomerViewModel;
using DynamicsOData.Models.DynamicsEntities;
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
        private ILockEntityService lockEntityService;

        public CustomerController(IODataService odataService, ILockEntityService lockEntityService)
        {
            this.odataService = odataService;
            this.lockEntityService = lockEntityService;
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

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            await odataService.UpdateCustomer(customer);

            return RedirectToAction("Index", new { customerGroupId = customer.CustomerGroupId, customerAccount = customer.CustomerAccount });
        }

        public async Task<JsonResult> RequestLock(string id)
        {
            bool locked = await lockEntityService.RequestLock("Customer", id, User.Identity.Name);

            return Json(locked);
        }

        public async Task<JsonResult> ReleaseLock(string id)
        {
            await lockEntityService.ReleaseLock("Customer", id, User.Identity.Name);

            return Json(true);
        }
    }
}