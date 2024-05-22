using app.Database;
using app.Dtos.BlogDtos;
using app.Dtos.PostDtos;
using app.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace app.Services.BlogServices
{
    public class BlogService : IBlogService
    {
        private readonly BlogDbContext dbContext;
        private readonly IMapper mapper;

        public BlogService(BlogDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<GetBlogDto>> AddBlog(CreateNewBlogDto newBlog)
        {
            var isBlog = await this.dbContext.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    b => string.Equals(b.Subject, newBlog.Subject)
                );

            if (isBlog is not null)
            {
                return null;
            }

            var blog = this.mapper.Map<Blog>(newBlog);
            blog.Id = Guid.NewGuid();

            this.dbContext.Blogs.Add(blog);
            await this.dbContext.SaveChangesAsync();

            return [..this.dbContext.Blogs
            .Select(
                b => this.mapper.Map<GetBlogDto>(b)
            )];
        }

        public Task<List<GetBlogDto>> DeleteBlog(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetBlogDto>> GetBlogs()
        {
            var blogs = this.dbContext
                            .Blogs
                            .Include(b => b.Posts)
                            .AsNoTracking();

            if (blogs is null)
            {
                return new();
            }

            List<GetBlogDto> mappedBlogs = new();

            foreach (var blog in blogs)
            {
                var newMappedBlog = this.mapper.Map<GetBlogDto>(blog);
                newMappedBlog.Posts = blog.Posts.Select(
                    p => this.mapper.Map<GetPostDto>(p)
                )
                .ToList();
                mappedBlogs.Add(newMappedBlog);
            }

            return mappedBlogs;
        }
    }
}