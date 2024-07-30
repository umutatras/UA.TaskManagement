using Microsoft.AspNetCore.Mvc;

namespace UA.TaskManagement.UI.Controllers.Admin
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
