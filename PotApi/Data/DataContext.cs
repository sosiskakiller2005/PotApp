using Microsoft.EntityFrameworkCore;
using PotApi.Models;
using PotApp.Models;

namespace PotApp.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoastDegree> RoastDegrees { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionProduct> SubscriptionProducts { get; set; }
        public DbSet<SubsriptionStatus> SubsriptionStatuses { get; set; }
        public DbSet<User> Users { get; set; }

        //public DataContext(DbContextOptions<DataContext> options) : base(options)
        //{
        //    //Database.Migrate();
        //}

        //protected DataContext()
        //{
        //}
    }
}
