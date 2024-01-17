using Microsoft.AspNetCore.Mvc;

namespace Gym.MVC.Areas.manage.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
