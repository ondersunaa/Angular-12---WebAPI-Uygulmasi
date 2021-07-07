using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KargoAPI.Core.Models;

namespace KargoAPI.Api.Dtos
{
    public class CargoInfoDTO
    {
        public int Id { get; set; }
        public string CargoNumber { get; set; }
        public Customer Customer { get; set; }
        public bool IsActive { get; set; }
        public DateTime DeliveryDates { get; set; }
        public string CurrentStatu { get; set; }
        public List<Product> Products { get; set; }
        public List<CargoStatuDTO> CargoStatuses { get; set; }
    }
}
