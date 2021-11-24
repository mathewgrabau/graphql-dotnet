using BlogPostsManagementSystem.DataAccess;
using BlogPostsManagementSystem.DataAccess.Models;
using HotChocolate;
using HotChocolate.Resolvers;
using System.Linq;

namespace BlogPostsManagementSystem.GraphQL
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorResolver([Service] IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author GetAuthor(BlogPost blogPost, IResolverContext ctx)
        {
            return _authorRepository.GetAuthors().Where(a => a.Id == blogPost.AuthorId).FirstOrDefault();
        }
    }
}
