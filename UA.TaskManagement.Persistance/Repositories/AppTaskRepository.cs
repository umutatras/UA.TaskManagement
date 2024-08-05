using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.DTOs;
using UA.TaskManagement.Application.Interfaces;
using UA.TaskManagement.Domain.Entities;
using UA.TaskManagement.Persistance.Context;
using UA.TaskManagement.Persistance.Extensions;

namespace UA.TaskManagement.Persistance.Repositories
{
    public class AppTaskRepository: IAppTaskRepository
    {
        private readonly TaskManagementContext _context;

        public AppTaskRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<PagedData<AppTask> >GetAllAsync(int activePage,int pageSize=10)
        {
            return await _context.Tasks.Include(x=>x.Priority).AsNoTracking().ToPagedListAsync(activePage,pageSize);
        }
    }
}
