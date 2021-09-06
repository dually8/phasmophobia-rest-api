using Microsoft.EntityFrameworkCore;

namespace PhasmoRESTApi.Models
{
    public class PhasmoContext : DbContext
    {
        public PhasmoContext(DbContextOptions<PhasmoContext> options) : base(options)
        {
        }

        public DbSet<Ghost> Ghosts { get; set; }

        public DbSet<Evidence> Evidences { get; set; }
    }
}