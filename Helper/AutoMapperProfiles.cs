using AutoMapper;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            createBookMap();
        }

        private void createBookMap()
        {
            CreateMap<Book, BookModel>();
            CreateMap<BookModel, Book>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}