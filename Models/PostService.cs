using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using gymblog1.Models;
using static gymblog1.Models.IdentityModels;

namespace gymblog1.Models
{
    public class PostService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public List<Post> GetAll(string search, string sort, int page)
        {
            var query = _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Title.Contains(search));

            // .NET 4.7.2 nekad pravi problem sa switch expression-om, pa koristimo klasičan switch
            switch (sort)
            {
                case "comments":
                    query = query.OrderByDescending(p => p.Comments.Count);
                    break;
                case "likes":
                    query = query.OrderByDescending(p => p.Likes.Count);
                    break;
                default:
                    query = query.OrderByDescending(p => p.CreatedAt);
                    break;
            }

            return query.Skip((page - 1) * 5).Take(5).ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Like(int id)
        {
            // Provjeri imaš li klasu Like definiranu s PostId poljem
            _context.Likes.Add(new Like { PostId = id });
            _context.SaveChanges();
        }

      
    }
}
