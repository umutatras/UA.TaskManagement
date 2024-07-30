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
    public class LoginRequestHandler : IRequestHandler<LoginRequest, Result<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<LoginResponseDto?>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var validator = new LoginRequestValidator();
            var validatonResult=await validator.ValidateAsync(request);
            if(validatonResult.IsValid)
            {
               var user=await _userRepository.GetByFilter(x=>x.Password==request.Password && x.UserName==request.Name);
                if(user!=null)
                {
                    return new Result<LoginResponseDto?>(new LoginResponseDto(user.Name, user.Surname, user.AppRoleId), true, null, null);
                }
                else
                {
                    return new Result<LoginResponseDto?>(null, false, "Kullanıcı adı veya şifre hatalı!", null);
                }
              
            }
            else
            {
                var errorList = validatonResult.Errors.ToMap();
                return new Result<LoginResponseDto?>(null, false, null, errorList);
            }
         
        }
    }
}
