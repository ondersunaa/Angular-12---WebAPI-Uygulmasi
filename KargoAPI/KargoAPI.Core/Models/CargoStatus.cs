using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace KargoAPI.Core.Models
{
   public class CargoStatus
    {
        public int Id { get; set; }
        public int StatuId { get; set; }
        public string CargoNumber { get; set; }
        public DateTime ChangeStatuDate { get; set; }
        public string Description { get; set; }
    }
}
