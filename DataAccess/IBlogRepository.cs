using BlogPostsManagementSystem.DataAccess.Models;
using System.Collections.Generic;

namespace BlogPostsManagementSystem.DataAccess
{
    public interface IBlogRepository
    {
        public List<BlogPost> GetBlogPosts();
        public BlogPost GetBlogPostById(int id);
    }
}
