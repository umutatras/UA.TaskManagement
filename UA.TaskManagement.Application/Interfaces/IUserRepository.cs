﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByFilter(Expression<Func<AppUser, bool>> filter);
    }
}
