using System;
using System.Collections.Generic;
using System.Text;

namespace KargoAPI.Core.Models
{
   public class CargoProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string CargoNumber { get; set; }
    }
}
