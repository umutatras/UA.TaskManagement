using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UA.TaskManagement.Application.DTOs
{
    public record Result<T>(T Data, bool IsSuccess, string? ErrorMessage,List<ValidationError>? Errors);

    public record ValidationError(string propertyName, string ErrorMessage); 
    public record NoData();
}
