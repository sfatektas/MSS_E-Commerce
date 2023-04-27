using E_Commerce.Entities.RequestFeatures.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.RequestFeatures
{
    public class SalesProductRequestParameter : RequestParameter
    {
        private string _category;


        private string _brand;

        private string _color;

        private string _size;

        private int _minPrice;

        private string _search;

        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value.ToString();
            }
        }
        public string Brand
        {
            get 
            { 
                return _brand;
            }
            set 
            {
                _brand = value.ToLower();
            }
        }

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value.ToLower();
            }
        }
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value.ToLower();
            }
        }

        public int MinPrice
        {
            get
            {
                return this._minPrice;
            }
            set
            {
                _minPrice = value < 0 ? 0 : value;
            }
        }
        public int MaxPrice { get; set; } = int.MaxValue;


        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value.ToLower();
            }
        }

    }
}
