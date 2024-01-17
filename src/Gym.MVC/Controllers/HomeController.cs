
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gym.MVC.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

       

    }
}