// DataContext is made to map the database
// it's from the Entity framework
using Blog2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blog2.Data
{
    public class BlogDataContext : DbContext // it's important that the class extends DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<PostTag> PostTags { get; set; } // those props don't have a primary key, so entity don't understand
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<Tag> Tags { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost,1433;database=Blog;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
            // options.LogTo(Console.WriteLine);
        }
    }
}