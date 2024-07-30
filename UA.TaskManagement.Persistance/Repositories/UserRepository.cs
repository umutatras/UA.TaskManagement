using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.Interfaces;
using UA.TaskManagement.Domain.Entities;
using UA.TaskManagement.Persistance.Context;

namespace UA.TaskManagement.Persistance.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly TaskManagementContext _context;

        public UserRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetByFilter(Expression<Func<AppUser,bool>> filter)
        {
            return await _context.Users.SingleOrDefaultAsync(filter);
        }
    }
}
