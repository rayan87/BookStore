using System.Collections.Generic;

namespace BookStore.Infrastructure.Pagination
{
    public interface IPagedData<T>
    {
        IList<T> Items {get;set;}
        
        int TotalRecordsCount {get;set;}
    }
}