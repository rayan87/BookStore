using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public IndexModel(ILogger<IndexModel> logger,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task OnGetAsync()
        {
            Books = _mapper.Map<List<BookModel>>(await _bookRepository.GetAll());
        }

        public List<BookModel> Books {get;set;}
    }
}
