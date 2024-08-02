using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.UI.Controllers.Admin
{
    public class PriorityController : Controller
    {
        private IMediator mediator;

        public PriorityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var result=await this.mediator.Send(new PriortyListRequest());
            return View(result.Data);
        }
        public IActionResult Create()
        {
            ViewBag.Active = "Priority";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PriortyCreateRequest request)
        {
            ViewBag.Active = "Priority";
            var result = await this.mediator.Send(request);
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
                    ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu, sistem üreticinize başvurun");
                }

                return View(request);
            }

        }
    }
}
