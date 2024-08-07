using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.DTOs;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Application.Interfaces
{
    public interface IAppTaskRepository
    {
        Task<PagedData<AppTask>> GetAllAsync(int activePage, string? s = null, int pageSize = 10);
        Task<int> CreateAsync(AppTask task);

    }
}
