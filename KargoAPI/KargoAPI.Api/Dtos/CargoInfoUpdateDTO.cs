using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace KargoAPI.Api.Dtos
{
    public class CargoInfoUpdateDTO
    {
        public int Id { get; set; }
        public string CargoNumber { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public int CurrentStatu { get; set; }
        public DateTime DeliveryDates { get; set; }
        public string Description { get; set; }
    }
}
