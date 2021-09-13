using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;

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