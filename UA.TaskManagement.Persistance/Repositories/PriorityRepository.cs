using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
