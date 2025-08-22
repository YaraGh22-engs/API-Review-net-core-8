using API_Review_net_core_8.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Review_net_core_8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
             
        }
        public DbSet<Category> Categories { get; set; }

    }
}
