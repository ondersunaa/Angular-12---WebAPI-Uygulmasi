using System;
using System.Collections.Generic;
using System.Text;

namespace KargoAPI.Service.Extension
{
   public class GetTokenOptions
    {
        public string SecurityKey { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public int AccessTokenExpiration { get; set; }
    }
}
