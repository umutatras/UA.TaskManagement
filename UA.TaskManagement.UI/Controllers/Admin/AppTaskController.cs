using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UA.TaskManagement.Application.Request;
using static UA.TaskManagement.Application.Request.AppTaskListRequest;

namespace UA.TaskManagement.UI.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppTaskController : Controller
    {
        private readonly IMediator mediator;

        public AppTaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> List(string? s, int activePage=1)
        {
            ViewBag.s = s;
            ViewBag.Active = "AppTask";
            var result = await this.mediator.Send(new AppTaskListRequest(activePage,s));
            return View(result);
        }
        public async Task<IActionResult> Create()
        {

            var result = await this.mediator.Send(new PriortyListRequest());

            ViewBag.Priorities = new List<SelectListItem>(result.Data.Select(x => new SelectListItem(x.Definition, x.Id.ToString())));


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppTaskCreateRequest request)
        {

            var result = await this.mediator.Send(request);


            ViewBag.Priorities = new List<SelectListItem>(result.Data.Priorities.Select(x => new SelectListItem(x.Definition, x.Id.ToString())));


            if (result.IsSuccess)
            {

                return RedirectToAction("List");
            }
            else
            {
                if (result.Errors?.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.propertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Sistemsel bir hata oluştu, üreticinize başvurun");
                }
            }

            return View(request);
        }
    }
}
