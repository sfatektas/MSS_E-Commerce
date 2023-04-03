using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.RequestFeatures
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; } // request header parametreleri

        public PagedList(IEnumerable<T> items, int count, int pageSize, int PageNumber)
        {
            MetaData = new(
                count,
                (int)Math.Ceiling(count/(double)pageSize),
                PageNumber,
                pageSize);
            AddRange(items); // list sınıfından kalıtıtm uyguladığımız için gelen verilei item olarak alıyorum.
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageSize, int pageNumber)
        {
            var items = source
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();
            var count = source.Count();
            return new PagedList<T>(items , count , pageSize , pageNumber);
        }
    }
}
