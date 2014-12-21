using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItsGitHub.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

    }
}