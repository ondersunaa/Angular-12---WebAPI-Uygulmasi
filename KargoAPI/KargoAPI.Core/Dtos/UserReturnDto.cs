using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace KargoAPI.Core.Dtos
{
   public class UserReturnDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
