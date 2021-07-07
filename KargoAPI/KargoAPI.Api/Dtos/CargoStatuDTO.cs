using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KargoAPI.Api.Dtos
{
    public class CargoStatuDTO
    {
        public int Id { get; set; }
        public string StatuName { get; set; }
        public string CargoNumber { get; set; }
        public DateTime ChangeStatuDate { get; set; }
        public string Description { get; set; }
    }
}
