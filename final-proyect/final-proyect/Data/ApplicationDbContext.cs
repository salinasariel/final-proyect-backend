using final_proyect_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace final_proyect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Enterprises> Enterprises { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
