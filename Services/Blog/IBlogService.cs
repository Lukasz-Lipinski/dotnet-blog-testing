using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.BlogDtos;

namespace app.Services.BlogServices
{
    public interface IBlogService
    {
        public Task<List<GetBlogDto>> GetBlogs();
        public Task<List<GetBlogDto>> AddBlog(CreateNewBlogDto newBlog);
        public Task<List<GetBlogDto>> DeleteBlog(Guid id);
    }
}