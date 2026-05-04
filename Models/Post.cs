using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gymblog1.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        // Maknut ApplicationUser ako ti pravi problem s Identity-em, 
        // ali za sada ostavljamo ako imaš definiranu klasu
        

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}