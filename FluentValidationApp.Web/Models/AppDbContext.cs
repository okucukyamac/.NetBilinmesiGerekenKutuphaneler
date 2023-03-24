using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FluentValidationApp.Web.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses{ get; set; }
    }
}
