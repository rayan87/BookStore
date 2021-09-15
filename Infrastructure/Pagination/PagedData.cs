using System.Collections.Generic;
using System.Linq;

namespace BookStore.Infrastructure.Pagination
{
    public class PagedData<T> : IPagedData<T>
    {

        // public PagedData(IQueryable<T> query, int start, int limit)
        // {
        //     TotalCount = query.Count();
        //     Items = query.Skip(start)
        //         .Take(limit)
        //         .ToList();
        // }

        public IList<T> Items {get;set;}

        public int TotalRecordsCount {get;set;}

        
    }
}