using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.TaskManagement.Application.Request
{
   public record AppTaskListRequest(int Id,string Title,string Description,string PriorityDefinition,bool State);
}
