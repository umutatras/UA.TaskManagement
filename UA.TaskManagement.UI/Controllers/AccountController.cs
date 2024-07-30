using MediatR;
using Microsoft.AspNetCore.Mvc;
using UA.TaskManagement.Application.DTOs;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest dto)
        {
           var result=await _mediator.Send(dto);
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
