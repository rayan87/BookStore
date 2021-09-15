using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Infrastructure;
using BookStore.Models;
using BookStore.Models.Pagination;
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
            // int limit = PageSize ?? 4;
            // int start = ((PageNo ?? 1) - 1) * limit; 

            var data = await _bookRepository.GetList(Pager.Start, Pager.Limit, SearchKeywords);
            Pager.TotalRecordsCount = data.TotalRecordsCount;
            
            Books = _mapper.Map<List<BookModel>>(data.Items);
        }

        public List<BookModel> Books {get;set;}

        // public int TotalPagesCount {get;set;}

        // public int TotalRecordsCount {get;set;}

        [BindProperty(SupportsGet = true)]
        public DataPager Pager {get;set;} = new DataPager();

        [BindProperty(SupportsGet = true, Name = "q")]
        public string SearchKeywords {get;set;}

        // [BindProperty(SupportsGet = true, Name = "p")]
        // public int? PageNo {get;set;}

        // [BindProperty(SupportsGet = true)]
        // public int? PageSize {get;set;}
    }
}
