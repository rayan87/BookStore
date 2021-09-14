using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.Infrastructure.Pagination;

namespace BookStore.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly StoreDbContext _dbContext;

        public BookRepository(StoreDbContext dbContext)
            => _dbContext = dbContext;

        public void Add(Book book)
        {
            _dbContext.Add(book);
        }

        public void Update(Book book)
        {
            _dbContext.Update(book);
        }

        public Task<List<Book>> GetAll()
        {
            return _dbContext.Books
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task<PagedData<Book>> GetList(int start, int limit)
        {
            var query = _dbContext.Books.AsQueryable()
                    .AsNoTracking()
                    .OrderByDescending(x => x.Id);

            return new PagedData<Book>()
            {
                TotalRecordsCount = await query.CountAsync(),
                Items = await query.Skip(start).Take(limit).ToListAsync()
            };
            //return new PagedData<Book>(query, start, limit);
            // var data = new PagedData<Book>();
            // data.TotalCount = await query.CountAsync();

            // data.Items = await query
            //     .OrderByDescending(x => x.Id)
            //     .Skip(start)
            //     .Take(limit)
            //     .ToListAsync();

            // return data;
        }

        public ValueTask<Book> GetById(int id)
        {
            return _dbContext.Books.FindAsync(id);
        }

        public void Remove(Book book)
        {
            _dbContext.Remove(book);
        }

        public Task SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }

    }
}