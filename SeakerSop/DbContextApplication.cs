using Microsoft.EntityFrameworkCore;
using SeakerSop.Models;

namespace SeakerSop
{
    public class DbContextApplication : DbContext
    {
       public DbSet<Order> Orders { get; set; }
       public DbSet<SneakersProduct> SneakersProducts { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<Cart> Carts { get; set; }
       public DbContextApplication(DbContextOptions<DbContextApplication> options) : base (options)
       {

       }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
            var ConfigurationFile = new ConfigurationBuilder().AddUserSecrets<DbContextApplication>().Build();
            var GetConnectStr = ConfigurationFile.GetConnectionString("EfCoreConnectionString");
            optionsBuilder.UseSqlServer(GetConnectStr);
       }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Users)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasOne(y => y.Users)
                .WithMany(y => y.Orders);
        }
    }
}
