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
    public class PriorityGetByIdHandler : IRequestHandler<PriortyGetByIdRequest, Result<PriorityListDto>>
    {
        private readonly IPriorityRepository repository;

        public PriorityGetByIdHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<PriorityListDto>> Handle(PriortyGetByIdRequest request, CancellationToken cancellationToken)
        {
            var priority = await this.repository.GetByFilterAsNoTrackingAsync(x => x.Id == request.id);
            if (priority != null)
            {
                return new Result<PriorityListDto>(new PriorityListDto(priority.Id, priority.Definition), true, null, null);

            }
            return new Result<PriorityListDto>(new PriorityListDto(0, ""), false, "Priority bulunamadı", null);



        }
    }
}
