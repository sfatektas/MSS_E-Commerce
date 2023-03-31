using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.RequestParameters
{
    public class RequestParameter 
    {
        public const int MaxPageSize = 50; 

        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set { 
                _pageSize = value < MaxPageSize ? value : MaxPageSize;
            }
        }
        public int PageNumber { get; set; }

    }
}
