using Microsoft.EntityFrameworkCore;
namespace ApiTest.Models
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>().HasKey(ass => new { ass.HardwareID, ass.SoftwareID, ass.UserID });


            modelBuilder.Entity<Assignment>()
              .HasOne(ass => ass.User)
             .WithMany(ass => ass.Assignment)
             .HasForeignKey(ass => ass.UserID);

            modelBuilder.Entity<Assignment>()
                .HasOne(ass => ass.Hardware)
                .WithMany(ass => ass.Assignment)
                .HasForeignKey(ass => ass.HardwareID);

            modelBuilder.Entity<Assignment>()
               .HasOne(ass => ass.Software)
               .WithMany(ass => ass.Assignment)
               .HasForeignKey(ass => ass.SoftwareID);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

    }
}
