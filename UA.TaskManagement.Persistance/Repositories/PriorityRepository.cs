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
    public class PriorityRepository : IPriorityRepository
    {
        private readonly TaskManagementContext _context;

        public PriorityRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Priority>> GetAllAsync()
        {
            return await _context.Priorities.AsNoTracking().ToListAsync();
        }
        public async Task DeleteAsync(Priority priority)
        {
            _context.Priorities.Remove(priority);
            await _context.SaveChangesAsync();
        }   

        public async Task<Priority?> GetByFilterAsync(Expression<Func<Priority, bool>> filter)
        {
            return await _context.Priorities.SingleOrDefaultAsync(filter);
        }

        public async Task<Priority?> GetByFilterAsNoTrackingAsync(Expression<Func<Priority, bool>> filter)
        {
            return await _context.Priorities.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<int> CreateAsync(Priority priority)
        {
           _context.Priorities.Add(priority);
            return  _context.SaveChangesAsync();
        }
    }
}
