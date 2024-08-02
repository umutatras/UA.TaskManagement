using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.Application.Validators
{
    public class PriorityCreateRequestValidator : AbstractValidator<PriortyCreateRequest>
    {
        public PriorityCreateRequestValidator()
        {
            this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım alanı boş bırakılamaz");
        }
    }
}