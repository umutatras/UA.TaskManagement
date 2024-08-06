using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.DTOs;

namespace UA.TaskManagement.Application.Request
{
    public record AppTaskListRequest : PagedRequest, IRequest<PagedResult<AppTaskListDto>>
    {
        public AppTaskListRequest(int activePage,string? s) : base(activePage)
        {
            S = s;
        }
        public string? S { get; set; }//searchstring
    }
}
