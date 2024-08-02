using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UA.TaskManagement.UI.Controllers.Admin
{
    public class PriorityController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            return View();
        }
    }
}
