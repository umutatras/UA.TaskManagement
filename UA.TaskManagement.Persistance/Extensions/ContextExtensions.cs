using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.DTOs;

namespace UA.TaskManagement.Persistance.Extensions
{
    public static class ContextExtensions
    {
        public static async Task<PagedData<T>> ToPagedListAsync<T>(this IQueryable<T> query,int activePage,int pageSize=10) where T : class,new()
        {
           var list= await query.AsNoTracking().Skip((1-activePage)*pageSize).Take(pageSize).ToListAsync();

            var totalPage = query.Count();

            return new PagedData<T>(list,activePage,totalPage,pageSize);

        }
    }
}
