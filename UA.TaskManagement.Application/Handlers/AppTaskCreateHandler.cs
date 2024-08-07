using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.DTOs;
using UA.TaskManagement.Application.Extensions;
using UA.TaskManagement.Application.Interfaces;
using UA.TaskManagement.Application.Validators;
using static UA.TaskManagement.Application.Request.AppTaskListRequest;

namespace UA.TaskManagement.Application.Handlers
{
    public class AppTaskCreateHandler : IRequestHandler<AppTaskCreateRequest, Result<AppTaskDto>>
    {
        private readonly IAppTaskRepository repository;
        private readonly IPriorityRepository priorityRepository;

        public AppTaskCreateHandler(IAppTaskRepository repository, IPriorityRepository priorityRepository)
        {
            this.repository = repository;
            this.priorityRepository = priorityRepository;
        }

        public async Task<Result<AppTaskDto>> Handle(AppTaskCreateRequest request, CancellationToken cancellationToken)
        {
            var priorities = await this.priorityRepository.GetAllAsync();

            var priorityDtoList = priorities.Select(x => new PriorityListDto(x.Id, x.Definition)).ToList();

            var validator = new AppTaskCreateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var rows = await this.repository.CreateAsync(request.ToMap());

                if (rows > 0)
                    return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), true, null, null);

                return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), false, "bir hata oluştu", null);
            }
            else
            {
                return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), false, null, validationResult.Errors.ToMap());
            }
        }
    }
}