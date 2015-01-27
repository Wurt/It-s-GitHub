using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItsGitHub.Models
{
    public class Response
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AssignmentId { get; set; }
        public string CreatorName { get; set; }
        public Assignment Assignment;
        public DateTime Created
        {
            get
            {
                return this._dateCreated.HasValue
                   ? this._dateCreated.Value
                   : DateTime.Now;
            }

            set { this._dateCreated = value; }
        }

        public virtual List<Comment> Comments { get; set; }
        private DateTime? _dateCreated = null;
    }

}

