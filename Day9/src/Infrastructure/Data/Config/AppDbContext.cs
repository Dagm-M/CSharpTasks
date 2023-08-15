using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // one to many relation
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(c => c.BlogPost)
                    .WithMany(bp => bp.Comment)
                    .HasForeignKey(c => c.BlogPostId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
