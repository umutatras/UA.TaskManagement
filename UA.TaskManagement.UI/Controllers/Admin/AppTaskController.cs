﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UA.TaskManagement.Application.Request;

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

        public async Task<IActionResult> List(int activePage=1)
        {
            ViewBag.Active = "AppTask";
            var result = await this.mediator.Send(new AppTaskListRequest(activePage));
            return View(result);
        }
    }
}
