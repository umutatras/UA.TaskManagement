﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.TaskManagement.Application.DTOs
{
   public record LoginResponseDto(string Name,string Surname,int roleId);
}
