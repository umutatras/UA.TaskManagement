using MediatR;
using UA.TaskManagement.Application.DTOs;
using UA.TaskManagement.Application.Extensions;
using UA.TaskManagement.Application.Interfaces;
using UA.TaskManagement.Application.Request;
using UA.TaskManagement.Application.Validators;

namespace UA.TaskManagement.Application.Handlers
{
    public class PriorityUpdateHandler : IRequestHandler<PriortyUpdateRequest, Result<NoData>>
    {
        private readonly IPriorityRepository repository;

        public PriorityUpdateHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(PriortyUpdateRequest request, CancellationToken cancellationToken)
        {

            var validator = new PriorityUpdateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var updatedEnity = await this.repository.GetByFilterAsync(x => x.Id == request.id);
                if (updatedEnity == null)
                    return new Result<NoData>(new NoData(), false, "İlgili aciliyet bulunamadı", null);

                updatedEnity.Definition = request.Definition ?? "";

                await this.repository.SaveChangesAsync();
                return new Result<NoData>(new NoData(), true, null, null);

            }
            else
            {
                var errors = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errors);
            }



        }
    }
}