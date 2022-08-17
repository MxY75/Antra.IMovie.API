using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.IMovie.Core.Model
{
    public class PagedResult<T> where T : class 
    {
        public PagedResult(IEnumerable<T> data, int page, int pageSize, long count)
        {
            Page = page;
            PageSize = pageSize;
            Count = count;
            Data = data;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        }

        public int Page { get; }
        public int PageSize { get; }
        public int TotalPages { get; set; }
        public long Count { get; set; }

        public bool HasPreviousPage => Page > 1;
        public bool HasNextPage => Page < TotalPages;

        public IEnumerable<T> Data { get; set; }
    }
    
}
