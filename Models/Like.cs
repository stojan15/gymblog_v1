using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gymblog1.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}