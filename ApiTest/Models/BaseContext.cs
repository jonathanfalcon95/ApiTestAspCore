using Microsoft.EntityFrameworkCore;
namespace ApiTest.Models
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<Software> Software { get; set; }

    }
}
