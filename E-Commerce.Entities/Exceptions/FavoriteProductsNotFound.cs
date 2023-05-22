using E_Commerce.Entities.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.Exceptions
{
    public class FavoriteProductsNotFound : NotFoundException
    {
        public FavoriteProductsNotFound(string message) : base(message)
        {
        }
        public FavoriteProductsNotFound(int id):base($"{id} id değerine sahip kullanıcının favori ürünü bulunmamaktadır.")
        {
            
        }
    }
}
