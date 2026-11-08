using Microsoft.EntityFrameworkCore;
using PotApp.Models;

namespace PotApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected DataContext()
        {
        }
    }
}
