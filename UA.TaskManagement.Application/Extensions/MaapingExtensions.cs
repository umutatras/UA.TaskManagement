using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.Enums;
using UA.TaskManagement.Application.Request;
using UA.TaskManagement.Domain.Entities;

namespace UA.TaskManagement.Application.Extensions
{
    public static class MaapingExtensions
    {
        public static AppUser ToMap(this RegisterRequest req)
        {
            return new AppUser
            {
                AppRoleId = (int)RoleType.Member,
                Name=req.Name,
                Password=req.Password,
                Surname=req.Surname,
                UserName = req.Username
            };
        }
        public static Priority ToMap(this PriortyCreateRequest request)
        {

            return new Priority
            {
                Definition = request.Definition,
            };
        }
        //public static AppTask ToMap(this AppTaskCreateRequest request)
        //{
        //    return new AppTask
        //    {
        //        Description = request.Description,
        //        Title = request.Title,
        //        PriorityId = request.PriorityId,
        //        State = false
        //    };
        //}
    }
}
