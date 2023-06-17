using Microsoft.EntityFrameworkCore;
using SeakerSop.Models;

namespace SeakerSop
{
    public class DbPayContext : DbContext
    {
        public DbSet<RequisitesUser> RequisitesUsers { get; set; }
        
        public DbPayContext (DbContextOptions<DbPayContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConfiguringPay = new ConfigurationBuilder().AddUserSecrets<DbPayContext>().Build();
            var ConnectionStr = ConfiguringPay.GetConnectionString("PayUserConnection");
            optionsBuilder.UseSqlServer(ConnectionStr);
        }
    }
}
