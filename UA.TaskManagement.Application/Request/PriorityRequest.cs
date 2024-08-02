using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.DTOs;

namespace UA.TaskManagement.Application.Request
{
    public record PriortyListRequest():IRequest<Result<List<PriorityListDto>>>;
    public record PriortyGetByIdRequest(int id):IRequest<Result<PriorityListDto>>;
    public record PriortyDeleteRequest(int id):IRequest<Result<NoData>>;
    public record PriortyUpdateRequest(int id,string Definition):IRequest<Result<NoData>>;
    public record PriortyCreateRequest(string? Definition) : IRequest<Result<NoData>>;

}
