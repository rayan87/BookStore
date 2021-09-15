using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Pagination;
using BookStore.Models.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<PagedData<Book>> Get([FromQuery]DataPager pager, string q) 
        {
            return await _bookRepository.GetList(pager.Start, pager.Limit, q);
        }
    }
}