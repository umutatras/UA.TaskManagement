using Microsoft.AspNetCore.Mvc;
using UA.TaskManagement.Application.DTOs;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginRequest dto)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
    }
}
