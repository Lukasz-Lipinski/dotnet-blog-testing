using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.PostDtos;

namespace app.Dtos.BlogDtos
{
    public record GetBlogDto
    {
        public string Subject { get; set; }
        public List<GetPostDto> Posts { get; set; }
    }

}