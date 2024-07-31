using FluentValidation;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.Application.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            this.RuleFor(x => x.Surname).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            this.RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");
        }
    }
}
