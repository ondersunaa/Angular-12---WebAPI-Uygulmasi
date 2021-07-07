using System;
using System.Collections.Generic;
using System.Text;

namespace KargoAPI.Core.Dtos
{
   public class TokenReturn
    {
        public string Token { get; set; }
        public DateTime TokenTime { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenTime { get; set; }
    }
}
