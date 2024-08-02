using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.DTOs;
using UA.TaskManagement.Application.Extensions;
using UA.TaskManagement.Application.Interfaces;
using UA.TaskManagement.Application.Request;
using UA.TaskManagement.Application.Validators;

namespace UA.TaskManagement.Application.Handlers
{
    public class PriorityCreateHandler : IRequestHandler<PriortyCreateRequest, Result<NoData>>
    {
        private readonly IPriorityRepository repository;

        public PriorityCreateHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(PriortyCreateRequest request, CancellationToken cancellationToken)
        {
            var validator = new PriorityCreateRequestValidator();
            var validationResult = validator.Validate(request);


            if (validationResult.IsValid)
            {
                var rowCount = await this.repository.CreateAsync(request.ToMap());
                if (rowCount > 0)
                {
                    return new Result<NoData>(new NoData(), true, null, null);
                }
                return new Result<NoData>(new NoData(), false, "Sistemsel bir hata oluştu, sistem üreticinize başvurun", null);
            }
            else
            {
                var errors = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errors);
            }

        }
    }
}