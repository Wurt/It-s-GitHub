using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItsGitHub.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string content { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}