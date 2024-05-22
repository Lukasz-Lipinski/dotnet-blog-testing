using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        // relations
        public Guid PostId { get; set; }
        public List<Post> Posts { get; set; }
    }
}