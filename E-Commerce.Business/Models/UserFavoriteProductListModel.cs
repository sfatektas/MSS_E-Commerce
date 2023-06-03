using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Models
{
    public class UserFavoriteProductListModel
    {
        public int Id { get; set; }
        public int ProductsInStockId { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public string Defination { get; set; }
        public double UnitPrice { get; set; }
    }
}