using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.UI.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PriorityController : Controller
    {
        private IMediator mediator;

        public PriorityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

     
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
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Active = "Priority";
            await this.mediator.Send(new PriortyDeleteRequest(id));
            return RedirectToAction("List");

        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Active = "Priority";
            var result = await this.mediator.Send(new PriortyGetByIdRequest(id));
            if (result.IsSuccess)
            {
                var requestModel = new PriortyUpdateRequest(result.Data.Id, result.Data.Definition);
                return View(requestModel);
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu, sistem üreticinize başvurun");
                var requestModel = new PriortyUpdateRequest(0, null);
                return View(requestModel);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(PriortyUpdateRequest request)
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
