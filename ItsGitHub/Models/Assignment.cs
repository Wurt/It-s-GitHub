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
        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;
    }
}