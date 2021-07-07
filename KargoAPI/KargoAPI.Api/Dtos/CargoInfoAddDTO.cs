using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KargoAPI.Core.Models;

namespace KargoAPI.Api.Dtos
{
    public class CargoInfoAddDTO
    {
        public string CargoNumber { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DeliveryDates { get; set; }
        public int CurrentStatu { get; set; }
        public List<Product> Products { get; set; }
        public string Description { get; set; }
    }
}
