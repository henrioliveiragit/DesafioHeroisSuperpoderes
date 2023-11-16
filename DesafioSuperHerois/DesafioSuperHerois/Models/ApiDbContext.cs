using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;


namespace DesafioSuperHerois.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Herois> Herois { get; set; }
        public DbSet<Superpoderes> Superpoderes { get; set; }
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
    }
}
