using Microsoft.EntityFrameworkCore;
using ForLimestone.Models;

namespace ForLimestone.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<CompanyUsers_IP_address> CompanyUsersIPAddresses { get; set; }
        public DbSet<IP_address> IP_Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyUsers_IP_address>().ToTable("CompanyUsersIP");
            modelBuilder.Entity<IP_address>().ToTable("IPaddresses");


            modelBuilder.Entity<CompanyUsers_IP_address>().HasMany(c => c.ListUsersIP);

        }
    }
}
