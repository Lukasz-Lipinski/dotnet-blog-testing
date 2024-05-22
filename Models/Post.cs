using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        //relations
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}