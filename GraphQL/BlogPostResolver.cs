using BlogPostsManagementSystem.DataAccess;
using BlogPostsManagementSystem.DataAccess.Models;
using HotChocolate.Resolvers;
using System.Collections.Generic;
using System.Linq;

namespace BlogPostsManagementSystem.GraphQL
{
    public class BlogPostResolver
    {
        private readonly IBlogRepository _blogPostRepository;
        
        public BlogPostResolver(IBlogRepository blogRepository)
        {
            _blogPostRepository = blogRepository;
        }

        public IEnumerable<BlogPost> GetBlogPosts(Author author, IResolverContext ctx)
        {
            return _blogPostRepository.GetBlogPosts().Where(b=>b.AuthorId == author.Id);
        }
    }
}
