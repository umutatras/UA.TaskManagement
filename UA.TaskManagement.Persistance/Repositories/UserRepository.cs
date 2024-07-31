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

        public async Task<int> CreateUserAsync(AppUser user)
        {
             _context.Users.Add(user);
            return await _context.SaveChangesAsync(); 
        }

        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser,bool>> filter,bool asNoTracking=true)
        {
            if(asNoTracking)
            {
                return await _context.Users.AsNoTracking().SingleOrDefaultAsync(filter);
            }
            return await _context.Users.SingleOrDefaultAsync(filter);

        }
    }
}
