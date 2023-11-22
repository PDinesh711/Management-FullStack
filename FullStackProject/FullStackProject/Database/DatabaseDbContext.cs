using FullStackProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackProject.Database
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions options) : base(options)
        {
        }

        //DbSet
        public DbSet<Login> logins { get; set; }
        public DbSet<Teachers>  teachers { get; set; }
        public DbSet<Students> students { get; set; }
        public DbSet<College> colleges { get; set; }
    }
}
