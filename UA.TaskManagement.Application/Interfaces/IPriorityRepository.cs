using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Application.Interfaces
{
    public interface IPriorityRepository
    {
        Task<List<Priority>> GetAllAsync();
        Task<int> CreateAsync(Priority priority);

        Task<Priority?> GetByFilterAsNoTrackingAsync(Expression<Func<Priority, bool>> filter);
        Task<Priority?> GetByFilterAsync(Expression<Func<Priority, bool>> filter);


        Task DeleteAsync(Priority priority);

        Task<int> SaveChangesAsync();

    }
}
