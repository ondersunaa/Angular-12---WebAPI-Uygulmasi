using System;
using System.Collections.Generic;
using System.Text;
using KargoAPI.Core.Services;

namespace KargoAPI.Core.Repository
{
   public interface ICargoInfoRepository<TEntity> : IServiceGeneric<TEntity> where TEntity:class
    {

    }
}
