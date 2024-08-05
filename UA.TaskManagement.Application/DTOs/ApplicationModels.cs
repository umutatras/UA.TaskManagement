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
  
    public record PagedResult<T>(List<T> Data, int ActivePage,int PageSize,int TotalCount);
    public record PagedData<T> where T : class, new()
    {
        public int ActivePage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; }
        public PagedData(List<T> data, int activePage, int totalCount, int pageSize)
        {
            this.Data = data;
            this.ActivePage = activePage;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        }
    }
}
