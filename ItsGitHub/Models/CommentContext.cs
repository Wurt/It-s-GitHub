using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ItsGitHub.Models
{
    public class CommentContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }
    }
}