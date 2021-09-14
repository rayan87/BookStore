using System;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Models.Pagination
{
    public class DataPager
    {
        public const int DefaultPageSize = 4;

        // private void setPagerInputs()
        // {
        //     int pageNo = Page ?? 1;
        //     int 
        // }

        public int Start
        {
            get 
            {
                return ((Page ?? 1) - 1) * Limit; 
            }
        }

        public int Limit
        {
            get {return PageSize ?? DefaultPageSize;}
        }

        [FromQuery(Name = "page")]
        public int? Page {get;set;}

        [FromQuery(Name = "page_size")]
        public int? PageSize {get;set;}

        public int TotalRecordsCount {get;set;}

        public int TotalPagesCount 
        {
            get 
            {
                int pagesCount = Math.DivRem(TotalRecordsCount, Limit, out int remainder);
                if (remainder > 0)
                    pagesCount++;
                
                return pagesCount;
            }
        }
    }
}