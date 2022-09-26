using Microsoft.EntityFrameworkCore;

namespace Zuri.Models
{
    public class ZuriContext : DbContext
    {
        public ZuriContext(DbContextOptions<ZuriContext> option) : base(option)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
