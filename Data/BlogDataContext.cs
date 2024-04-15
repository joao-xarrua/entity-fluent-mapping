// DataContext is made to map the database
// it's from the Entity framework
using Microsoft.EntityFrameworkCore;

namespace Blog2.Data
{
    public class BlogDataContext : DbContext // it's important that the class extends DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost,1433;database=Blog;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
        }
    }
}