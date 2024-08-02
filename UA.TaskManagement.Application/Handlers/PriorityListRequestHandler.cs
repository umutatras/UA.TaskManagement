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
    public class PriorityListRequestHandler : IRequestHandler<PriortyListRequest, Result<List<PriorityListDto>>>
    {
        private readonly IPriorityRepository _repository;

        public PriorityListRequestHandler(IPriorityRepository repository)        {
            _repository = repository;
        }

        public async Task<Result<List<PriorityListDto>>> Handle(PriortyListRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            var mappedResult=result.Select(x=>new PriorityListDto(x.Id,x.Definition)).ToList();
            return new Result<List<PriorityListDto>>(mappedResult, true,null,null);
        }
    }
}
