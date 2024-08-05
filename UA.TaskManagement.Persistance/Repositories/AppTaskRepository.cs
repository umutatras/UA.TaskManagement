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
    public class AppTaskRepository: IAppTaskRepository
    {
        private readonly TaskManagementContext _context;

        public AppTaskRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<List<AppTask>> GetAllAsync()
        {
            return await _context.Tasks.Include(x=>x.Priority).AsNoTracking().ToListAsync();
        }
    }
}
