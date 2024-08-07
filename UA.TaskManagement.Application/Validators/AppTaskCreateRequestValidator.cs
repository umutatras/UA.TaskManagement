using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.Handlers;
using static UA.TaskManagement.Application.Request.AppTaskListRequest;

namespace UA.TaskManagement.Application.Validators
{
    public class AppTaskCreateRequestValidator : AbstractValidator<AppTaskCreateRequest>
    {
        public AppTaskCreateRequestValidator()
        {
            this.RuleFor(x => x).NotEmpty().WithMessage("Başlık bilgisi boş olamaz");
            this.RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama bilgisi boş olamaz");
        }
    }
}