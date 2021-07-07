using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KargoAPI.Core.Dtos
{
  public  class CreateReturnUserDto
    {
        public bool Ok { get; set; }
        public CreateUserDto CreateUserDto { get; set; }
        public List<string> ErrorList { get; set; }
    }
}
