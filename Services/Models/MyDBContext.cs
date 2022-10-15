using Microsoft.EntityFrameworkCore;

namespace Services.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _con = "data source=BS-962\\SA;initial catalog=LocalizationDB;integrated security=True;persist security info=True"; 
            optionsBuilder.UseSqlServer(_con);
        }
    }
}
