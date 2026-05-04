using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gymblog1.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
    public class PostTag
    {
        [Key]
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}