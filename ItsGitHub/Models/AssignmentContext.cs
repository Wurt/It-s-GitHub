using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ItsGitHub.Models
{
    public class AssignmentContext : DbContext
    {
        public DbSet<Assignment> Assignment { get; set; }
    }
}