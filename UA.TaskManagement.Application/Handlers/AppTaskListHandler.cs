using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.DTOs;
using UA.TaskManagement.Application.Interfaces;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.Application.Handlers
{
    public class AppTaskListHandler : IRequestHandler<AppTaskListRequest, Result<List<AppTaskListDto>>>
    {
        private readonly IAppTaskRepository _repository;

        public AppTaskListHandler(IAppTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<AppTaskListDto>>> Handle(AppTaskListRequest request, CancellationToken cancellationToken)
        {
            var list=await _repository.GetAllAsync();
            var result= new List<AppTaskListDto>();
            foreach (var appTask in list)
            {
                var dto = new AppTaskListDto(appTask.Id, appTask.Title, appTask.Description, appTask.Priority?.Definition, appTask.State);
                result.Add(dto);
            }
           
            return new Result<List<AppTaskListDto>>(result,true,null,null);
        }
    }
}
