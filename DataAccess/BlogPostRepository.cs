using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogPostsManagementSystem.DataAccess
{

    public class BlogPostRepository : IBlogRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public BlogPostRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (ApplicationDbContext db = _dbContextFactory.CreateDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public BlogPost GetBlogPostById(int id)
        {
            using (ApplicationDbContext db = _dbContextFactory.CreateDbContext())
            {
                return db.BlogPosts.SingleOrDefault(a => a.Id == id);
            }
        }

        public List<BlogPost> GetBlogPosts()
        {
            using (ApplicationDbContext db = _dbContextFactory.CreateDbContext())
            {
                return db.BlogPosts.ToList();
            }
        }
    }
}
