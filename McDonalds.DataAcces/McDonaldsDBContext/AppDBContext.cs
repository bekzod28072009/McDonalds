using McDonalds.Domein.Entity.Menu;
using McDonalds.Domein.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace McDonalds.DataAcces.McDonaldsDBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Sandwiches> sandwiches { get; set; }

        public DbSet<Breakfast> breakfasts { get; set; }

        public DbSet<Desserts_Bakery> desserts { get; set; }

    }
}
