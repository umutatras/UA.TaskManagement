using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.TaskManagement.Application.Request;

namespace UA.TaskManagement.Application.Validators
{
    public class PriorityUpdateRequestValidator : AbstractValidator<PriortyUpdateRequest>
    {
        public PriorityUpdateRequestValidator()
        {
            this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım bilgisi boş olamaz");
        }
    }
}