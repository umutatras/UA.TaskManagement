using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            return View(new LoginRequest("",""));
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest dto)
        {
           var result=await _mediator.Send(dto);
            if(result.IsSuccess)
            {
               await SetAuthCookie(result.Data,dto.RememberMe);

                return RedirectToAction("Index", "Home",new {area="Admin"});
            }
            else
            {
                if(result.Errors!=null&&result.Errors.Count>0)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.propertyName, item.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu,sistem üreticinize başvurun");
                    return View(dto);
                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest req)
        {
            var result = await _mediator.Send(req);
            if(result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            else
            {

                if (result.Errors != null && result.Errors.Count > 0)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.propertyName, item.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu,sistem üreticinize başvurun");
                    return View(req);
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private async Task SetAuthCookie(LoginResponseDto dto,bool rememberMe)
        {
            // User => 

            User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name);

            var claims = new List<Claim>
        {
            new Claim("Name", dto.Name),
            new Claim("Surname", dto.Surname),
            new Claim(ClaimTypes.Role, dto.role.ToString()),
        };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = rememberMe,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}

