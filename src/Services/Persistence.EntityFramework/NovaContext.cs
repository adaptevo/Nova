using System.Data.Entity;
using Nova.Core.Domain;

namespace Nova.Services.Persistence.EntityFramework
{
    public class NovaContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
