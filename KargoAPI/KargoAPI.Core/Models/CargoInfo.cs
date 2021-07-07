using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace KargoAPI.Core.Models
{
  public class CargoInfo
    {
        public int Id { get; set; }
        public string CargoNumber { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DeliveryDates { get; set; }
        public int CurrentStatu { get; set; }

    }
}
