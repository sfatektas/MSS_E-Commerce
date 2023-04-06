using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class Brand : BaseEntity
    {
        [NotMapped]
        private string myVar;

        public string Defination
        {
            get { return myVar; }
            set { myVar = value.ToLower(); }
        }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}
