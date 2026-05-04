using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace gymblog1.Models
{
    public class IdentityModels
    {
        public class ApplicationUser : IdentityUser
        {
        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public DbSet<Post> Posts { get; set; }
            public DbSet<MacroTracker> MacroTrackers { get; set; }
            public DbSet<Like> Likes { get; set; }
            // Dodaj ostale tablice ako ih imaš (Comments, Tags...)

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
    }
}