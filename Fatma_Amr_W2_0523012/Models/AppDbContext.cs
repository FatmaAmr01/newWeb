using Fatma_Amr_W2_0523012.Models.Entitties;
using Microsoft.EntityFrameworkCore;

namespace Fatma_Amr_W2_0523012.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamMemer> teamMemers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>()
                .HasMany(x => x.tasks)
                .WithOne(x => x.Project)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tasks>()
                .HasOne(x => x.Project)
                .WithMany(x => x.tasks)
                .OnDelete(DeleteBehavior.NoAction);
      
               
              
        }
    }
}
