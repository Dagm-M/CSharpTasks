using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
