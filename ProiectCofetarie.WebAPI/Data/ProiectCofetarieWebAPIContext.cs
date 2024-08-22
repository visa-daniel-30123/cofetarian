using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectCofetarie.Library.Models;

namespace ProiectCofetarie.WebAPI.Data
{
    public class ProiectCofetarieWebAPIContext : DbContext
    {
        public ProiectCofetarieWebAPIContext (DbContextOptions<ProiectCofetarieWebAPIContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<IstoricComenzi> IstoricComenzis { get; set; }
    }
}
