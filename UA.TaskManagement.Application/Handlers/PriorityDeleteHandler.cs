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
    public class PriorityDeleteHandler : IRequestHandler<PriortyDeleteRequest, Result<NoData>>
    {
        private readonly IPriorityRepository repository;

        public PriorityDeleteHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(PriortyDeleteRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByFilterAsync(x => x.Id == request.id);
            if (deletedEntity != null)
            {
                await this.repository.DeleteAsync(deletedEntity);
                return new Result<NoData>(new NoData(), true, null, null);
            }
            return new Result<NoData>(new NoData(), false, "Silinecek aciliyet bulunamadı", null);
        }
    }
}