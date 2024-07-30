using MediatR;
using UA.TaskManagement.Application.DTOs;

namespace UA.TaskManagement.Application.Request
{
    public record LoginRequest(string? Name, string? Password, bool RememberMe = false) :IRequest<Result<LoginResponseDto?>>;
}
