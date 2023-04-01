using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.RequestFeatures
{
    public class MetaData
    {
        public MetaData(int ıtemCount, int totalPage, int currentPage , int pageSize)
        {
            ItemCount = ıtemCount;
            TotalPage = totalPage;
            CurrentPage = currentPage;
            HasPrev = currentPage > 1;
            HasNext = totalPage > currentPage;
            PageSize = pageSize;
        }

        public int ItemCount { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPrev { get;}
        public bool HasNext { get;}
    }
}
