using KitapDükkanı.Models;
using Microsoft.EntityFrameworkCore;

namespace KitapDükkanı.utility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options): base (options) { }

        public DbSet<KitapTuru> KitapTurleri { get; set; }
    }
}
