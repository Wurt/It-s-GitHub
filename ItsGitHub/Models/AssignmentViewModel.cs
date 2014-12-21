using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItsGitHub.Models
{
    public class AssignmentViewModel
    {
        public List<Comment> Comments { get; set; }
        public Assignment Assignment { get; set; }
    }
}