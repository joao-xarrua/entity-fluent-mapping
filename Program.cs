using Blog2.Data;
using Blog2.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            /* using (var context = new BlogDataContext())
            {
                 ADDING NEW REGISTRY
                // var category = new Category { Name = "ASP.NET", Slug = "aspnet" };
                // context.Categories.Add(category);

                // UPDATING REGISTRY
                // var category = context.Categories.FirstOrDefault(x => x.Id == 1);
                // category.Name = ".NET";
                // category.Slug = "dotnet"; 
                // context.Update(category);

                // REMOVING REGISTRY
                // var category = context.Categories.FirstOrDefault(x => x.Id == 1);
                // context.Remove(category);

                // after adding the tag, it will be stored on the DbContext memory of entity
                // context.SaveChanges(); // we need to run SaveChanges to send the changes to the database 
            }*/

            /* creating new user, category and post            
            using var context = new BlogDataContext();
            var user = new User
            {
                Name = "João",
                Slug = "joao",
                Email = "joao@mail.com",
                Bio = "9x microsoft mvp",
                Image = "http://aa",
                PasswordHash = "1234"
            };
            var category = new Category { Name = "Backend", Slug = "backend" };
            var post = new Post
            {
                Author = user,
                Category = category,
                Body = "<p>Hello world</p>",
                Slug = "comecando-com-ef-core",
                Summary = "Neste artigo vamos aprender EF core",
                Title = "Começando com EF Core",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            };

            context.Posts.Add(post);
            context.SaveChanges();
            */

            using var context = new BlogDataContext();
            var posts = context
            .Posts
            .AsNoTracking()
            .Include(x => x.Author)
            // .Where(x => x.AuthorId == 1)
            .OrderByDescending(x => x.LastUpdateDate)
            .ToList();

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Title} escrito por {post.Author?.Name}");
            }


        }
    }
}