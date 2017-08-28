using DynamicsOData.Models;
using DynamicsOData.Models.CustomerGroupViewModel;
using DynamicsOData.Models.DynamicsEntities;
using DynamicsOData.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DynamicsOData.Controllers
{
    [Authorize]
    public class CustomerGroupController : Controller
    {
        private IODataService odataService;
        private ILockEntityService lockEntityService;

        public CustomerGroupController(IODataService odataService, ILockEntityService lockEntityService)
        {
            this.odataService = odataService;
            this.lockEntityService = lockEntityService;
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

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerGroup group)
        {
            await odataService.UpdateCustomerGroup(group);

            return RedirectToAction("Index", new { customerGroupId = group.CustomerGroupId });
        }

        public async Task<JsonResult> RequestLock(string id)
        {
            try
            {
                await lockEntityService.RequestLock<CustomerGroup>(id, User.Identity.Name);

                return Json(true);
            }
            catch (LockEntityException)
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> ReleaseLock(string id)
        {
            try
            {
                await lockEntityService.ReleaseLock<CustomerGroup>(id, User.Identity.Name);

                return Json(true);
            }
            catch (LockEntityException)
            {
                return Json(false);
            }
        }
    }
}