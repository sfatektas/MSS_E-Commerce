using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.RequestFeatures.Abstract
{
    public class RequestParameter
    {
        public const int MaxPageSize = 20;
        public int PageNumber { get; set; }

        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value < MaxPageSize ? value : MaxPageSize;
            }
        }
        public string OrderBy { get; set; } // nullable
    }
}
