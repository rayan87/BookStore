using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Data;

namespace BookStore.Infrastructure
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        ValueTask<Book> GetById(int id);

        Task SaveChanges();

        void Add(Book book);

        void Remove(Book book);

        void Update(Book book);
    }
}