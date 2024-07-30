using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.Enums;

namespace UA.TaskManagement.Application.DTOs
{
   public record LoginResponseDto(string Name,string Surname, RoleType role);
}
