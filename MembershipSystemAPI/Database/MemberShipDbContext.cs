using MembershipSystemAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MembershipSystemAPI.Database
{
    public class MemberShipDbContext:DbContext
    {
        public MemberShipDbContext()
        {

        }
        public DbSet<Person>People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1NRATPK\\SQLEXPRESS;Database=MemberShipDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasIndex(x => x.Email).IsUnique();
            //
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(20);
            modelBuilder.Entity<Person>().Property(x => x.LastName).HasMaxLength(20);
            //
            modelBuilder.Entity<Person>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<Person>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Person>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<Person>().Property(x => x.Email).IsRequired();
           

        }
    }
}
