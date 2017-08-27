using Microsoft.AspNetCore.Mvc;

namespace DynamicsOData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
