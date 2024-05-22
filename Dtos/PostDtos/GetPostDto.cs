using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.PostDtos
{
    public record GetPostDto
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}