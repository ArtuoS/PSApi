using Microsoft.EntityFrameworkCore;

namespace PremierAPI.Models
{
    public class PremierContext : DbContext
    {
        public PremierContext(DbContextOptions<PremierContext> options)
            : base(options)
        { }

        public DbSet<User> Usuarios { get; set; }
    }
}
