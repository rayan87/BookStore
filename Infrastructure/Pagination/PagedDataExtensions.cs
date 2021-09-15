using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Pagination
{
    public static class PagedDataExtensions
    {
        
        public async static Task<IPagedData<T>> ToPagedDataAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            var pager = new PagedData<T>(pageNumber, pageSize, await query.CountAsync());
            pager.Items = await query
                .Skip(pager.Start)
                .Take(pager.PageSize)
                .ToListAsync();

            return pager;
        }

    }
}