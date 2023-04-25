using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lena.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lena.DataAccess.Concrete.EntityFramework
{
    public class LenaContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=JARVIS;DataBase=LenaDb;Trusted_connection=true;");
        }
        public DbSet<User> Users { get; set; }
    }
}
