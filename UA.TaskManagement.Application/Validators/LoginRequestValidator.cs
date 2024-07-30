using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.Application.Validators
{
    public class LoginRequestValidator:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");
        }
    }
}
