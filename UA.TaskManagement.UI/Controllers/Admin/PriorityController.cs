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
    }
}
