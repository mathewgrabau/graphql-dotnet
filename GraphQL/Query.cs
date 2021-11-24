using BlogPostsManagementSystem.DataAccess;
using BlogPostsManagementSystem.DataAccess.Models;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPostsManagementSystem.GraphQL
{
    public class Query
    {
        public async Task<List<Author>> GetAllAuthors([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender)
        {
            List<Author> authors = authorRepository.GetAuthors();
            await eventSender.SendAsync("ReturnedAuthors", authors);
            return authors;
        }

        public async Task<Author> GetAuthorById([Service] IAuthorRepository authorRepository, [Service] ITopicEventSender eventSender, int id)
        {
            Author author = authorRepository.GetAuthorById(id);
            await eventSender.SendAsync("ReturnedAuthor", author);
            return author;
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync([Service] IBlogRepository blogRepository, [Service] ITopicEventSender eventSender)
        {
            List<BlogPost> blogPosts = blogRepository.GetBlogPosts();
            await eventSender.SendAsync("ReturnedBlogPosts", blogPosts);
            return blogPosts;
        }

        public async Task<BlogPost> GetBlogPostById([Service] IBlogRepository blogRepository, [Service] ITopicEventSender eventSender, int id)
        {
            BlogPost blogPost = blogRepository.GetBlogPostById(id);
            await eventSender.SendAsync("ReturnedBlogPost", blogPost);
            return blogPost;
        }
    }
}
