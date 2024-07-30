using Microsoft.AspNetCore.Mvc;

namespace UA.TaskManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
