using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItsGitHub.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ResponseId { get; set; }
        public Response Response;
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

        private DateTime? _dateCreated = null;
    }
}
