using Microsoft.EntityFrameworkCore;

using BlogPostsManagementSystem.DataAccess.Models;

namespace BlogPostsManagementSystem.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Author author1 = new Author { Id = 1, FirstName = "AFirstName", LastName = "ALastName" };
            Author author2 = new Author { Id = 2, FirstName = "BFirstName", LastName = "BLastName" };
            Author author3 = new Author { Id = 3, FirstName = "CFirstName", LastName = "CLastName" };

            modelBuilder.Entity<Author>().HasData(author1, author2, author3);

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    AuthorId = 1,
                    Title = "Introducing C# 10"
                },
                new BlogPost
                {
                    Id = 2,
                    AuthorId = 2,
                    Title = "Introducing Entity Framework Core"
                },
                new BlogPost
                {
                    Id = 3,
                    AuthorId = 1,
                    Title = "Introducing Kubernetes"
                },
                new BlogPost
                {
                    Id = 4,
                    AuthorId = 2,
                    Title = "Introducing Machine Learning"
                },
                new BlogPost
                {
                    Id = 5,
                    AuthorId = 3,
                    Title = "Introducing DevSecOps"
                }
                );
        }
    }
}
