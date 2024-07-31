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
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, Result<NoData>>
    {
        private readonly IUserRepository _userRepository;

        public RegisterRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<NoData>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var validator =new RegisterRequestValidator();
            var validationResult=await validator.ValidateAsync(request);
            if(validationResult.IsValid)
            {

          var rowCount= await _userRepository.CreateUserAsync(request.ToMap());
                if(rowCount > 0)
                {
                    return new Result<NoData>(new NoData(),true,null,null);
                }
                else
                {
                    return new Result<NoData>(new NoData(), false, "Kayıt eklenemedi.", null);
                }
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errorList);
            }
           
        }
    }
}
