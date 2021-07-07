using System;
using System.Collections.Generic;
using System.Text;
using KargoAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KargoAPI.Data.Context
{
   public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Statu> Status { get; set; }
        public DbSet<CargoInfo> CargoInfos { get; set; }
        public DbSet<CargoProduct> CargoProducts { get; set; }
        public DbSet<CargoStatus> CargoStatuses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
