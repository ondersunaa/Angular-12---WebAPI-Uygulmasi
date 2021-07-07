using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KargoAPI.Core.UnitOfWork;
using KargoAPI.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace KargoAPI.Data.UnitOfWork
{
   public class UnitOfWork:IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CommmitAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
