using BlogPostsManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostsManagementSystem.DataAccess
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public AuthorRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var db = _dbContextFactory.CreateDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            using (ApplicationDbContext db = _dbContextFactory.CreateDbContext())
            {
                await db.Authors.AddAsync(author);
                await db.SaveChangesAsync();
                return author;
            }
        }

        public Author GetAuthorById(int id)
        {
            using (ApplicationDbContext db = _dbContextFactory.CreateDbContext())
            {
                return db.Authors.SingleOrDefault(a=>a.Id == id);
            }
        }

        public List<Author> GetAuthors()
        {
            using (ApplicationDbContext db = _dbContextFactory.CreateDbContext())
            {
                return db.Authors.ToList();
            }
        }
    }
}
