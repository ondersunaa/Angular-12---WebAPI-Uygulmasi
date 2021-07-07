using System;
using System.Collections.Generic;
using System.Text;

namespace KargoAPI.Core.Models
{
   public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
    }
}
