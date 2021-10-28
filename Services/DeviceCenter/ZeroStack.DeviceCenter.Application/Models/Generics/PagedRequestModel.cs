using System.Collections.Generic;
using ZeroStack.DeviceCenter.Application.Services.Generics;
using ZeroStack.DeviceCenter.Domain.Constants;

namespace ZeroStack.DeviceCenter.Application.Models.Generics
{
    public class PagedRequestModel
    {
        public virtual IEnumerable<SortingDescriptor>? Sorter { get; set; }

        public virtual int PageNumber { get; set; } = 1;

        public virtual int PageSize { get; set; } = PagingConstants.DefaultPageSize;
    }
}
