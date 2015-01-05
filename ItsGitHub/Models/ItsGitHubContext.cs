using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ItsGitHub.Models
{
    public class ItsGitHubContext : DbContext
    {
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Response> Response { get; set; }
       
    }
}