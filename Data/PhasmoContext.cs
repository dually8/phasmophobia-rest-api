using Microsoft.EntityFrameworkCore;
using PhasmoRESTApi.Models;

namespace PhasmoRESTApi.Data
{
    public class PhasmoContext : DbContext
    {
        public PhasmoContext(DbContextOptions<PhasmoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ghost_Evidence>()
                .HasOne(x => x.Ghost)
                .WithMany(x => x.Ghost_Evidences)
                .HasForeignKey(x => x.GhostId);

            modelBuilder.Entity<Ghost_Evidence>()
                .HasOne(x => x.Evidence)
                .WithMany(x => x.Ghost_Evidences)
                .HasForeignKey(x => x.EvidenceId);
        }

        public DbSet<Ghost> Ghosts { get; set; }
        public DbSet<Evidence> Evidences { get; set; }
        public DbSet<Ghost_Evidence> Ghost_Evidences { get; set; }
    }
}