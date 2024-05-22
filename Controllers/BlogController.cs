using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.BlogDtos;
using app.Dtos.PostDtos;
using app.Models;
using app.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController(IBlogService blogService) : ControllerBase
    {
        private readonly IBlogService blogService = blogService;

        [HttpGet("all")]
        public async Task<ActionResult<GetPostDto>> GetAllBlogs()
        {
            return Ok(await this.blogService.GetBlogs());
        }

        [HttpPost("create")]
        public async Task<ActionResult<Blog>> CreateBlog([FromBody] CreateNewBlogDto newBlog)
        {
            if (newBlog is { Subject: null })
            {
                return BadRequest("Invalid data");
            }
            return Ok(await this.blogService.AddBlog(newBlog));
        }
    }
}