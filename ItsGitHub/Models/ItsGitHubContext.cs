using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ItsGitHub.Models
{
    public class ApplicationUser : IdentityUser
    {
    }
    public class ItsGitHubContext : DbContext
    {
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Response> Response { get; set; }
    }

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("ItsGitHubContext")
        {
        }
    }
}